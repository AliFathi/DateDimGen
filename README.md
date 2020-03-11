# DateDimGen
Use PersianDateDimention to generate report queries.

- Create the dimention table using query inside `sql\cretae-table.sql` file.
- fill the table by invoking the `Generator.Run()` method. by default, it will insert 5844 rows, from *2016-03-20* (1395-01-01 persian) to *2032-03-19* (1410-12-29 persian), i.e. 15 years. don't forget to set the `_connectionString` field of the `Generator` class.
- create report queries using `ToJoinReport` and `ToLeftJoinReport` extension methods.
