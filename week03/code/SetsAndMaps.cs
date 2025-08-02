using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning allsymmetric pairs of words.  
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seenWords = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word.Length != 2 || word[0] == word[1])
            {
                continue;
            }

            string reversedWord = new string(new[] { word[1], word[0] });

            if (seenWords.Contains(reversedWord))
            {
                result.Add($"{word} & {reversedWord}");
            }
            else
            {
                seenWords.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 3)
            {
                string degree = fields[3].Trim();
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees.Add(degree, 1);
                }
            }
        }
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // This corrected version avoids creating large temporary strings, fixing the OutOfMemoryException.
        var charCounts = new Dictionary<char, int>();

        // 1. Count characters in the first word, ignoring case and spaces on the fly.
        foreach (char c in word1)
        {
            if (char.IsWhiteSpace(c)) continue; // Ignore spaces

            char lowerChar = char.ToLower(c);
            if (charCounts.ContainsKey(lowerChar))
            {
                charCounts[lowerChar]++;
            }
            else
            {
                charCounts[lowerChar] = 1;
            }
        }

        // 2. Decrement counts using the second word.
        foreach (char c in word2)
        {
            if (char.IsWhiteSpace(c)) continue; // Ignore spaces

            char lowerChar = char.ToLower(c);
            // If word2 has a character that word1 doesn't, or too many of one, it's not an anagram.
            if (!charCounts.ContainsKey(lowerChar) || charCounts[lowerChar] == 0)
            {
                return false;
            }
            charCounts[lowerChar]--;
        }

        // 3. Finally, check if any counts are left over. If so, word1 had extra characters.
        foreach (var count in charCounts.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        
        var results = new List<string>();
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature?.Properties != null && feature.Properties.Place != null && feature.Properties.Mag.HasValue)
                {
                    results.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag.Value}");
                }
            }
        }
        
        return results.ToArray();
    }
}