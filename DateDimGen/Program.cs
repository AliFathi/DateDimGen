using DateDimGen.Report;
using static System.Console;

namespace DateDimGen
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Generator.Run();

            //var fac = new Report.ReportInputFactory(new Report.DateTimeService());

            //var inputs = new (int, Report.PersianReportInput)[]{
            //    (01, fac.CreatePersian(takeYear: 2)),
            //    (05, fac.CreatePersian(takeMonth: 6)),

            //    (11, fac.CreatePersian(fromMonth: 2)),
            //    (12, fac.CreatePersian(fromMonth: 2, toMonth: 9)),
            //    (13, fac.CreatePersian(fromMonth: 2, fromYear: 1378)),
            //    (14, fac.CreatePersian(fromMonth: 2, toYear: 1378)),
            //    (15, fac.CreatePersian(fromMonth: 2, fromYear: 1367, toYear: 1378)),
            //    (16, fac.CreatePersian(fromMonth: 2, fromYear: 1367, toMonth: 4)),
            //    (17, fac.CreatePersian(fromMonth: 2, fromYear: 1367, toYear: 1373, toMonth: 4)),

            //    (18, fac.CreatePersian(toMonth: 5)),
            //    (20, fac.CreatePersian(toMonth: 5, fromYear: 1345)),
            //    (21, fac.CreatePersian(toMonth: 5, toYear: 1345)),
            //    (22, fac.CreatePersian(toMonth: 5, toYear: 1345, fromYear: 1340)),

            //    (23, fac.CreatePersian(toYear: 1399)),
            //    (24, fac.CreatePersian(fromYear: 1380)),
            //    (25, fac.CreatePersian(fromYear: 1380, toYear: 1387)),

            //    (26, fac.CreatePersian()),

            //    (27, fac.CreatePersian(month: 1)),
            //    (28, fac.CreatePersian(month: 2)),
            //    (28, fac.CreatePersian(month: 12)),
            //    (29, fac.CreatePersian(month: 7, year: 1264)),
            //    (30, fac.CreatePersian(month: 12, year: 1264)),
            //    (31, fac.CreatePersian(year: 1345)),

            //    (32, fac.CreatePersian(takeDays: 1)),
            //    (33, fac.CreatePersian(takeDays: 7)),
            //    (33, fac.CreatePersian(takeDays: 365)),
            //};

            //foreach (var i in inputs)
            //    WriteLine(i.Item1.ToString().PadLeft(2, '0') + ": " + i.Item2);

            var keyGen = new DateReportRangeGenerator();
            foreach (var r in keyGen.GenerateByPersianDay<int>(from: new System.DateTime(2021, 03, 21), to: new System.DateTime(2021, 03, 22)))
                WriteLine(r.Day);

            WriteLine();
            WriteLine("finish");
        }
    }
}
