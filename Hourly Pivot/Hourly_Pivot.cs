// Copyright QUANTOWER LLC. © 2017-2021. All rights reserved.

using System;
using System.Drawing;
using System.Linq;
using TradingPlatform.BusinessLayer;

namespace Hourly_Pivot
{
    /// <summary>
    /// An example of blank indicator. Add your code, compile it and use on the charts in the assigned trading terminal.
    /// Information about API you can find here: http://api.quantower.com
    /// Code samples: https://github.com/Quantower/Examples
    /// </summary>
	public class Hourly_Pivot : Indicator
    {
        /// <summary>
        /// Indicator's constructor. Contains general information: name, description, LineSeries etc. 
        /// </summary>
        /// 

        /*[InputParameter("Selected symbol", 20)]
        public Symbol symbol;*/

        public Hourly_Pivot()
            : base()
        {
            // Defines indicator's name and description.
            Name = "Hourly_Pivot";
            Description = "created by ChrisMoody by request for pippo, adapted on C# by Atro. Hourly Pivots points.";

            // Defines line on demand with particular parameters.
            AddLineSeries("h_pivot", Color.CadetBlue, 2, LineStyle.Dot);
            AddLineSeries("h_r1", Color.Fuchsia, 2, LineStyle.Dot);
            AddLineSeries("h_s1", Color.Magenta, 2, LineStyle.Dot);
            AddLineSeries("h_r2", Color.GreenYellow, 2, LineStyle.Dot);
            AddLineSeries("h_s2", Color.DarkGreen, 2, LineStyle.Dot);
            AddLineSeries("h_r3", Color.Red, 2, LineStyle.Dot);
            AddLineSeries("h_s3", Color.DarkRed, 2, LineStyle.Dot);


            // By default indicator will be applied on main window of the chart
            SeparateWindow = false;
        }

        /// <summary>
        /// This function will be called after creating an indicator as well as after its input params reset or chart (symbol or timeframe) updates.
        /// </summary>
        protected override void OnInit()
        {
            //INIT
        }
        /// <summary>
        /// Calculation entry point. This function is called when a price data updates. 
        /// Will be runing under the HistoricalBar mode during history loading. 
        /// Under NewTick during realtime. 
        /// Under NewBar if start of the new bar is required.
        /// </summary>
        /// <param name="args">Provides data of updating reason and incoming price.</param>
        protected override void OnUpdate(UpdateArgs args)
        {
            //HistoricalData historicalData = this.symbol.GetHistory(Period.HOUR1, DateTime.UtcNow.AddDays(-1));

            // Add your calculations here.         
            /*double Low = ((HistoryItemBar)historicalData[0]).Low;    // Get PREVIOUS bar low
            double High = ((HistoryItemBar)historicalData[0]).High;   // Get CURRENT  bar open
            double Close = ((HistoryItemBar)historicalData[0]).Close;  // Get CURRENT  bar close
            */

            double High = GetPrice(PriceType.High);
            double Low = GetPrice(PriceType.Low);
            double Close = GetPrice(PriceType.Close);

            double pivot = (High + Low + Close) / 3.0; //Typical marche aussi
            double r1 = pivot + (pivot - Low);
            double s1 = pivot - (High - pivot);
            double r2 = pivot + (High - Low);
            double s2 = pivot - (High - Low);
            double r3 = r1 + (High - Low);
            double s3 = s1 - (High - Low);

            //
            // An example of settings values for indicator's lines
            // -----------------------------------------------
            //            
            SetValue(pivot);                              // To set value for first line of the indicator
            SetValue(r1, 1);                              // To set value for second line of the indicator
            SetValue(s1, 2);                              // To set value for third line of the indicator
            SetValue(r2, 3);                              // To set value for forth line of the indicator
            SetValue(s2, 4);                              // To set value for fifth line of the indicator
            SetValue(r3, 5);                              // To set value for sixth line of the indicator
            SetValue(s3, 6);                              // To set value for seventh line of the indicator

            //SetValue(this.Open());
        }
    }
}

