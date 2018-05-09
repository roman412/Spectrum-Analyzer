﻿using OxyPlot;
using OxyPlot.Wpf;
using System.Threading;
using System.Windows.Threading;

namespace SpectrumAnalyzer.Helpers
{
    static class IO
    {
        internal static void SaveImage(Plotter plotModel, string fileName, Dispatcher dispatcher)
        {
            var thread = new Thread(() =>
            {
                dispatcher.Invoke(() => _saveImage(plotModel, fileName));
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void _saveImage(Plotter plotModel, string fileName)
        {
            PngExporter.Export((plotModel.PlotFrame), fileName, 960, 720, OxyColors.White);
        }
    }
}
