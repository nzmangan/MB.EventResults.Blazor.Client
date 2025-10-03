# MB.EventResults.Blazor.Client

A Blazor component library for displaying orienteering event results and statistics. This library provides a set of components to visualize and analyze event data.

## Installation

Install the package from NuGet:

```
dotnet add package MB.EventResults.Blazor.Client
```

## Usage

1.  **Register services**

    In your `Program.cs`, register the required services:

    ```csharp
    using MB.EventResults.Blazor.Client.Core;

    builder.Services.AddEventResultsBlazorClient();
    ```

2.  **Include static assets**

    In your main `index.html` or `_Host.cshtml` file, include the following CSS and JavaScript files:

    ```html
    <link href="/_content/MB.EventResults.Blazor.Client/css/additional.css" rel="stylesheet">
    <link href="/_content/MB.EventResults.Blazor.Client/css/main.css" rel="stylesheet">
    <link href="/_content/MB.EventResults.Blazor.Client/css/style.css" rel="stylesheet" />
    <link href="/_content/MB.EventResults.Blazor.Client/css/fonts.css" rel="stylesheet" />
    <script src="/_content/MB.EventResults.Blazor.Client/js/decode.js"></script>
    <script src="/_content/MB.EventResults.Blazor.Client/js/brotliInterop.js"></script>
    <script src="/_content/MB.EventResults.Blazor.Client/js/graphs.js"></script>
    <script src="/_content/MB.EventResults.Blazor.Client/js/page.js"></script>
    <script src="/_content/MB.EventResults.Blazor.Client/js/chart.min.js"></script>
    ```

3.  **Use the main component**

    You can use the `MainComponent` to display the main view with all the graphs and options.

    ```razor
    @page "/results"

    <MB.EventResults.Blazor.Client.Components.MainComponent />
    ```

## Features

The library includes a variety of components for data visualization:

*   **MainComponent**: The primary component that orchestrates the display of various graphs and controls.
*   **Graphs**:
    *   `Matrix`: Displays a results matrix.
    *   `Mistake`: Shows mistake details.
    *   `MistakeTotal`: Total mistakes.
    *   `Pack`: Pack running analysis.
    *   `PerformanceIndex`: Runner performance index.
    *   `PerformanceIndexHistogram`: Histogram of performance indexes.
    *   `PerformanceIndexHistogramNormalized`: Normalized histogram of performance indexes.
    *   `PerformanceIndexNormalized`: Normalized performance index.
    *   `PositionLeg`: Position per leg.
    *   `PositionTotal`: Total position.
    *   `Time`: Time analysis.
    *   `HeadToHead`: Head-to-head comparison.
    *   `HallOfFame`: Hall of Fame display.
    *   `Data`: Raw data view.
    *   `ClassMistakeTotal`: Total mistakes for a class.
    *   `ClassPerformanceIndex`: Class performance index.
    *   `ClassPerformanceIndexHistogram`: Histogram of class performance indexes.
    *   `ClassPerformanceIndexHistogramNormalized`: Normalized histogram of class performance indexes.
    *   `ClassPerformanceIndexNormalized`: Normalized class performance index.

## License

This project is licensed under the [MIT License](https://github.com/nzmangan/MB.EventResults.Blazor.Client/blob/main/LICENSE).

## Contributing

Contributions are welcome! Please feel free to open an issue or submit a pull request on the [GitHub repository](https://github.com/nzmangan/MB.EventResults.Blazor.Client).
