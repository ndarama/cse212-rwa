using System.Collections.Generic;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    /// <summary>
    /// A list of earthquake features from the GeoJSON data.
    /// The JsonSerializer maps the "features" array in the JSON to this property.
    /// </summary>
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Represents a single feature (an earthquake event) from the GeoJSON data.
/// </summary>
public class Feature
{
    /// <summary>
    /// Contains the detailed properties of the feature.
    /// The JsonSerializer maps the "properties" object in the JSON to this property.
    /// </summary>
    public FeatureProperties Properties { get; set; }
}

/// <summary>
/// Represents the properties of an earthquake feature, holding the specific
/// data points we are interested in (place and magnitude).
/// </summary>
public class FeatureProperties
{
    /// <summary>
    /// The geographical location of the earthquake.
    /// </summary>
    public string Place { get; set; }

    /// <summary>
    /// The magnitude of the earthquake. This is a nullable double (double?) to
    /// correctly handle cases where the magnitude might be null in the JSON data.
    /// </summary>
    public double? Mag { get; set; }
}