using RecordTypes.App;
using System;
using System.Collections.Generic;

DailyTemperature[] data = GetTemperatureData();

foreach (var item in data)
    Console.WriteLine(item);

DailyTemperatureClassic[] dataClassic = GetTemperatureDataClassic();
foreach (var item in dataClassic)
    Console.WriteLine(item);

Console.ReadLine();
Console.WriteLine();

var heatingDegreeDays = new HeatingDegreeDays(65, data);
Console.WriteLine(heatingDegreeDays);

var coolingDegreeDays = new CoolingDegreeDays(65, data);
Console.WriteLine(coolingDegreeDays);

// Growing degree days measure warming to determine plant growing rates
var growingDegreeDays = coolingDegreeDays with { BaseTemperature = 41 };
//Console.WriteLine(growingDegreeDays);

//var growingDegreeDaysCopy = coolingDegreeDays with { };

// showing moving accumlation of 5 days using range syntax
List<CoolingDegreeDays> movingAccumulation = new();
int rangeSize = (data.Length > 5) ? 5 : data.Length;
for (int start = 0; start < data.Length - rangeSize; start++)
{
    var fiveDayTotal = growingDegreeDays with { TempRecords = data[start..(start + rangeSize)] };
    movingAccumulation.Add(fiveDayTotal);
}
Console.WriteLine();
Console.WriteLine("Total degree days in the last five days");
foreach (var item in movingAccumulation)
{
    Console.WriteLine(item);
}

static DailyTemperature[] GetTemperatureData() =>
    new DailyTemperature[]
    {
        new DailyTemperature(HighTemp: 57, LowTemp: 30),
        new DailyTemperature(60, 35),
        new DailyTemperature(63, 33),
        new DailyTemperature(68, 29),
        new DailyTemperature(72, 47),
        new DailyTemperature(75, 55),
        new DailyTemperature(77, 55),
        new DailyTemperature(72, 58),
        new DailyTemperature(70, 47),
        new DailyTemperature(77, 59),
        new DailyTemperature(85, 65),
        new DailyTemperature(87, 65),
        new DailyTemperature(85, 72),
        new DailyTemperature(83, 68),
        new DailyTemperature(77, 65),
        new DailyTemperature(72, 58),
        new DailyTemperature(77, 55),
        new DailyTemperature(76, 53),
        new DailyTemperature(80, 60),
        new DailyTemperature(85, 66)
    };

static DailyTemperatureClassic[] GetTemperatureDataClassic() =>
    new DailyTemperatureClassic[]
    {
        new DailyTemperatureClassic(highTemp: 57, lowTemp: 30),
        new DailyTemperatureClassic(60, 35),
        new DailyTemperatureClassic(63, 33),
        new DailyTemperatureClassic(68, 29),
        new DailyTemperatureClassic(72, 47),
        new DailyTemperatureClassic(75, 55),
        new DailyTemperatureClassic(77, 55),
        new DailyTemperatureClassic(72, 58),
        new DailyTemperatureClassic(70, 47),
        new DailyTemperatureClassic(77, 59),
        new DailyTemperatureClassic(85, 65),
        new DailyTemperatureClassic(87, 65),
        new DailyTemperatureClassic(85, 72),
        new DailyTemperatureClassic(83, 68),
        new DailyTemperatureClassic(77, 65),
        new DailyTemperatureClassic(72, 58),
        new DailyTemperatureClassic(77, 55),
        new DailyTemperatureClassic(76, 53),
        new DailyTemperatureClassic(80, 60),
        new DailyTemperatureClassic(85, 66)
    };