using static System.Console;

namespace DateDimGen
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Generator.Run();

            //var fac = new Report.ReportInputFactory(new DateTimeService());

            //var inputs = new (int, Report.ReportInput)[]{
            //    (01, fac.Create(takeYears: 2)),
            //    (05, fac.Create(takeMonths: 6)),

            //    (11, fac.Create(fromMonth: 2)),
            //    (12, fac.Create(fromMonth: 2, toMonth: 9)),
            //    (13, fac.Create(fromMonth: 2, fromYear: 1378)),
            //    (14, fac.Create(fromMonth: 2, toYear: 1378)),
            //    (15, fac.Create(fromMonth: 2, fromYear: 1367, toYear: 1378)),
            //    (16, fac.Create(fromMonth: 2, fromYear: 1367, toMonth: 4)),
            //    (17, fac.Create(fromMonth: 2, fromYear: 1367, toYear: 1373, toMonth: 4)),

            //    (18, fac.Create(toMonth: 5)),
            //    (20, fac.Create(toMonth: 5, fromYear: 1345)),
            //    (21, fac.Create(toMonth: 5, toYear: 1345)),
            //    (22, fac.Create(toMonth: 5, toYear: 1345, fromYear: 1340)),

            //    (23, fac.Create(toYear: 1399)),
            //    (24, fac.Create(fromYear: 1380)),
            //    (25, fac.Create(fromYear: 1380, toYear: 1387)),

            //    (26, fac.Create()),

            //    (27, fac.Create(month: 1)),
            //    (28, fac.Create(month: 2)),
            //    (28, fac.Create(month: 12)),
            //    (29, fac.Create(month: 7, year: 1264)),
            //    (30, fac.Create(month: 12, year: 1264)),
            //    (31, fac.Create(year: 1345)),

            //    (32, fac.Create(takeDays: 1)),
            //    (33, fac.Create(takeDays: 7)),
            //    (33, fac.Create(takeDays: 365)),
            //};

            //foreach (var i in inputs)
            //    WriteLine(i.Item1.ToString().PadLeft(2, '0') + ": " + i.Item2);

            //var keyGen = new Report.ReportRangeGenerator();
            //foreach (var r in keyGen.GenerateByPersianDay<int>(from: new System.DateTime(2021, 03, 21), to: new System.DateTime(2021, 03, 22)))
            //    WriteLine(r.Day);

            WriteLine();
            WriteLine("finish");
        }
    }
}
