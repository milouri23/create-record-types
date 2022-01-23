using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordTypes.App
{
    public class DailyTemperatureClassic
    {
        public double HighTemp { get; }
        public double LowTemp { get; }
        public double Mean => (HighTemp + LowTemp) / 2.0;

        public DailyTemperatureClassic(double highTemp, double lowTemp)
        {
            HighTemp = highTemp;
            LowTemp = lowTemp;
        }

        // To string method that would generate the compiler
        // If this was a record
        public override string? ToString()
        {
            var builder = new StringBuilder();
            builder.Append(nameof(DailyTemperatureClassic));
            builder.Append(" { ");

            if (PrintMembers(builder))
                builder.Append(' ');

            builder.Append('}');
            return builder.ToString();
        }

        private bool PrintMembers(StringBuilder builder)
        {
            builder.Append(nameof(HighTemp));
            builder.Append(" = ");
            builder.Append(HighTemp);

            builder.Append(", ");

            builder.Append(nameof(LowTemp));
            builder.Append(" = ");
            builder.Append(LowTemp);

            builder.Append(", ");

            builder.Append(nameof(Mean));
            builder.Append(" = ");
            builder.Append(Mean);

            return true;
        }
    }

    //public readonly record struct DailyTemperature(double HighTemp, double LowTemp);

    public readonly record struct DailyTemperature(double HighTemp, double LowTemp)
    {
        public double Mean => (HighTemp + LowTemp) / 2.0;
    }

    public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
    {
        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append(nameof(BaseTemperature));
            builder.Append(" = ");
            builder.Append(BaseTemperature);

            return true;
        }
    }

    public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
        : DegreeDays(BaseTemperature, TempRecords)
    {
        public double DegreesDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
    }

    public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
        : DegreeDays(BaseTemperature, TempRecords)
    {
        public double DegreesDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
    }
}