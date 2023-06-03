using System;
using Infrastructure.Common;

namespace Infrastructure.Statistics.SqlQueries
{
    public static class SqlQuery
    {
        public static string InComePerMonthQuery(DateTime start, DateTime finish)
        {
            var startDate = start.GetSqlDateTimeFormat();
            var finishDate = finish.GetSqlDateTimeFormat();
            var query =
                $"declare @startDate datetime ;declare @endDate datetime; set @startDate = '{startDate}'; set @endDate = '{finishDate}' ; with monthlyRange (startMonth, startNextMonth) as (select dateadd (m, datediff (m, 0, @startDate), 0),dateadd (m, datediff (m, 0, @startDate) + 1, 0) union all select dateadd (m, 1, startMonth), dateadd (m, 1, startNextMonth) from monthlyRange where startNextMonth <= dateadd (m, datediff (m, 0, @endDate), 0)) SELECT Year(monthlyRange.startMonth) Year, Month(monthlyRange.startMonth) Month, ISNULL(SUM(ContractPayments.Amount),0) Total FROM monthlyRange left join ContractPayments on monthlyRange.startMonth <= ContractPayments.PaidAt and monthlyRange.startNextMonth > ContractPayments.PaidAt GROUP BY Year(monthlyRange.startMonth), Month(monthlyRange.startMonth) order by 1, 2";


            return query;
        }


        public static string SpendPerMonthQuery(DateTime start, DateTime finish)
        {

            var startTime = start.GetSqlDateTimeFormat();
            var finishTime = finish.GetSqlDateTimeFormat();
            var query =
                $"declare @startDate datetime; declare @endDate datetime; set @startDate = '{startTime}'; set @endDate = '{finishTime}'; with monthlyRange (startMonth, startNextMonth) as (select dateadd (m, datediff (m, 0, @startDate), 0),dateadd (m, datediff (m, 0, @startDate) + 1, 0) union all select dateadd (m, 1, startMonth), dateadd (m, 1, startNextMonth) from monthlyRange where startNextMonth <= dateadd (m, datediff (m, 0, @endDate), 0))SELECT Year(monthlyRange.startMonth) Year, Month(monthlyRange.startMonth) Month, ISNULL(SUM(Spends.Amount),0) Total FROM monthlyRange  left join Spends on monthlyRange.startMonth <= Spends.SpentAt and monthlyRange.startNextMonth > Spends.SpentAt GROUP BY Year(monthlyRange.startMonth), Month(monthlyRange.startMonth) order by 1, 2";

            return query;
        }

        public static string IncomeThatEmployeeMadePerMonth(DateTime startTime, DateTime endTime, int employeeId)
        {
            var start = startTime.ToAzDateTime().GetSqlDateTimeFormat();
            var end = endTime.ToAzDateTime().GetSqlDateTimeFormat();
            var query =
                $"declare @startDate datetime; declare @endDate datetime; set @startDate = '{start}'; set @endDate = '{end}'; with monthlyRange(startMonth, startNextMonth) as (select dateadd (m, datediff(m, 0, @startDate), 0),dateadd(m, datediff(m, 0, @startDate) + 1, 0) union all select dateadd(m, 1, startMonth), dateadd(m, 1, startNextMonth) from monthlyRange where startNextMonth <= dateadd(m, datediff(m, 0, @endDate), 0)) SELECT Year(monthlyRange.startMonth) Year, Month(monthlyRange.startMonth) Month, ISNULL(SUM(cp.Amount), 0) Total FROM monthlyRange left join(select EmployeeId, ContractId, Amount, PaidAt from Contracts as c inner join ContractPayments cpp on c.Id = cpp.ContractId) as cp  on monthlyRange.startMonth <= cp.PaidAt and monthlyRange.startNextMonth > cp.PaidAt and cp.EmployeeId = {employeeId} GROUP BY Year(monthlyRange.startMonth), Month(monthlyRange.startMonth) order by 1, 2;";

            return query;
        }

        public static string InComePerYearAndContractType(DateTime startTime, DateTime endTime, int contractType)
        {
            startTime = startTime.ToAzDateTime();
            endTime = endTime.ToAzDateTime();

            var query =
                $"declare @startDate datetime;declare @endDate datetime;set @startDate = '{startTime}';set @endDate = '{endTime}';declare @contractType int;;set @contractType = {contractType}; ; with yearlyRange (startYear, startNextYear) as (select dateadd (YEAR ,datediff (YEAR, 0, @startDate), 0), dateadd (YEAR, datediff (YEAR, 0, @startDate) + 1, 0) union all select dateadd (YEAR, 1, startYear), dateadd (YEAR, 1, startNextYear) from yearlyRange where startNextYear <= dateadd (YEAR, datediff (YEAR, 0, @endDate), 0)) SELECT Year(yearlyRange.startYear) Year, ISNULL(SUM(cp.Amount),0) Total, ISNULL(cp.ContractType, @contractType) as ContractType FROM yearlyRange left join (select EmployeeId, ContractId, Amount, PaidAt, ContractType from Contracts as c inner join ContractPayments cpp on c.Id = cpp.ContractId) as cp on yearlyRange.startYear <= cp.PaidAt and yearlyRange.startNextYear > cp.PaidAt and cp.ContractType = @contractType GROUP BY Year(yearlyRange.startYear),cp.ContractType order by 1, 2;";

            return query;
        }

        public static string IncomePerMonthByDateAndContractType(DateTime startAt, DateTime endsAt, int contractType)
        {
            var start = startAt.ToAzDateTime().GetSqlDateTimeFormat();
            var end = endsAt.ToAzDateTime().GetSqlDateTimeFormat();

            var query =
                $"declare @startDate datetime;declare @endDate datetime;declare @contractType int;set @startDate = '{start}' set @endDate = '{end}'; set @contractType = {contractType}; ; with monthlyRange (startMonth, startNextMonth) as (select dateadd (m, datediff (m, 0, @startDate), 0), dateadd (m, datediff (m, 0, @startDate) + 1, 0) union all select dateadd (m, 1, startMonth), dateadd (m, 1, startNextMonth) from monthlyRange where startNextMonth <= dateadd (m, datediff (m, 0, @endDate), 0)) SELECT Year(monthlyRange.startMonth) Year, Month(monthlyRange.startMonth) Month,ISNULL(SUM(cp.Amount), 0) Total FROM monthlyRange left join (select EmployeeId, ContractId, Amount, PaidAt, ContractType from Contracts as c inner join ContractPayments cpp on c.Id = cpp.ContractId) as cp on monthlyRange.startMonth <= cp.PaidAt and monthlyRange.startNextMonth > cp.PaidAt and cp.ContractType = @contractType GROUP BY Year(monthlyRange.startMonth), Month(monthlyRange.startMonth) order by 1, 2";

            return query;
        }

        public static string EmployeePaymentDetails(int id, DateTime startTime, DateTime endTime)
        {
            var start = startTime.ToAzDateTime().GetSqlDateTimeFormat();
            var end = endTime.ToAzDateTime().GetSqlDateTimeFormat();
            var query = @$"DECLARE @startDate datetime
                        DECLARE @endDate datetime
                        SET @startDate = '{start}'
                        SET @endDate = '{end}'
                        ;WITH monthlyRange (startMonth, startNextMonth) AS (
                        SELECT DATEADD(m, DATEDIFF(m, 0, @startDate), 0),
                        DATEADD(m, DATEDIFF(m, 0, @startDate) + 1, 0)
                        UNION ALL
                        SELECT DATEADD(m, 1, startMonth),
                        DATEADD(m, 1, startNextMonth)
                        FROM monthlyRange
                        WHERE startNextMonth <= DATEADD(m, DATEDIFF(m, 0, @endDate), 0))
                        SELECT
	                    e.Id,
	                    e.FullName as EmployeeName,
                        CONVERT(datetime, FORMAT(DATEFROMPARTS(YEAR(m.startMonth), MONTH(m.startMonth), 1), 'dd/MM/yyyy'), 103) AS DateTime,
                        ISNULL(p.Paid, 0) AS PaymentAmount,
	                    ISNULL(p.Extras, 0) AS Extras,
                        ISNULL(pp.PrePaid, 0) AS PrePaid,
                        ISNULL(pun.PunishmentAmount, 0) AS Punishments,
	                    (ISNULL(p.Paid,0) + ISNULL(p.Extras,0)) - (ISNULL(pp.PrePaid,0) + ISNULL(pun.PunishmentAmount,0)) as TotalReceived
                        FROM monthlyRange m
                        CROSS JOIN Employees e
                        LEFT JOIN (
                            SELECT 
                                ep.EmployeeId,
                                YEAR(ep.PaidTime) AS Year,
                                MONTH(ep.PaidTime) AS Month,
                                SUM(ep.Amount) as Paid,
                        		SUM(ep.ExtraAmount) as Extras
                            FROM EmployeePayments ep
                            GROUP BY ep.EmployeeId, YEAR(ep.PaidTime), MONTH(ep.PaidTime)
                        ) p ON p.EmployeeId = e.Id AND p.Year = YEAR(m.startMonth) AND p.Month = MONTH(m.startMonth)
                        LEFT JOIN (
                            SELECT 
                                pp.EmployeeId,
                                YEAR(pp.DateTime) AS Year,
                                MONTH(pp.DateTime) AS Month,
                                SUM(pp.Amount) AS PrePaid
                            FROM PrePayments pp
                            GROUP BY pp.EmployeeId, YEAR(pp.DateTime), MONTH(pp.DateTime)
                        ) pp ON pp.EmployeeId = e.Id AND pp.Year = YEAR(m.startMonth) AND pp.Month = MONTH(m.startMonth)
                        LEFT JOIN (
                            SELECT 
                                epun.EmployeeId,
                                YEAR(epun.At) AS Year,
                                MONTH(epun.At) AS Month,
                                SUM(epun.Amount) AS PunishmentAmount
                            FROM EmployeePunishments epun
                            GROUP BY epun.EmployeeId, YEAR(epun.At), MONTH(epun.At)
                        ) pun ON pun.EmployeeId = e.Id AND pun.Year = YEAR(m.startMonth) AND pun.Month = MONTH  (m.startMonth)
                        GROUP BY YEAR(m.startMonth), MONTH(m.startMonth), e.Id, e.FullName, p.Paid, pp.PrePaid,             pun.PunishmentAmount,p.Extras
                        having e.Id = {id}
                        ORDER BY 1, 2";

            return query;
        }
    }
}
