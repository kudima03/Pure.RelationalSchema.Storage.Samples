using System.Collections;
using Pure.RelationalSchema.Samples.Columns;
using Pure.RelationalSchema.Storage.Abstractions;
using Pure.RelationalSchema.Storage.Samples.Cells;
using Pure.RelationalSchema.Storage.Samples.Records;
using Pure.RelationalSchema.Storage.Samples.TableDataSets;

namespace Pure.RelationalSchema.Storage.Samples.Tests.Records;

public sealed record UserRecordsTests
{
    [Fact]
    public void CountIs6()
    {
        Assert.Equal(6, new UserRecords().Count());
    }

    [Fact]
    public void MirrorsRowCount()
    {
        Assert.Equal(new UsersTableDataSet().Count(), new UserRecords().Count());
    }

    [Fact]
    public void NonGenericEnumeratorEnumeratesEveryRecord()
    {
        IEnumerator enumerator = ((IEnumerable)new UserRecords()).GetEnumerator();

        int count = 0;
        while (enumerator.MoveNext())
        {
            _ = Assert.IsType<UserRecord>(enumerator.Current);
            count++;
        }

        Assert.Equal(6, count);
    }

    [Fact]
    public void MirrorsUserIdText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.UserId).TextValue),
            rows.Select(row => row.Cells[new UserIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserTenantIdText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.UserTenantId).TextValue
            ),
            rows.Select(row => row.Cells[new UserTenantIdColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserNameText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.UserName).TextValue),
            rows.Select(row => row.Cells[new UserNameColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsSignupDateText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.SignupDate).TextValue),
            rows.Select(row => row.Cells[new SignupDateColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserActiveText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.UserActive).TextValue),
            rows.Select(row => row.Cells[new UserActiveColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsLastLoginText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.LastLogin).TextValue),
            rows.Select(row => row.Cells[new LastLoginColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserAgeText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.UserAge).TextValue),
            rows.Select(row => row.Cells[new UserAgeColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsShiftStartText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.ShiftStart).TextValue),
            rows.Select(row => row.Cells[new ShiftStartColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserScoreText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record => new InvariantCellText(record.UserScore).TextValue),
            rows.Select(row => row.Cells[new UserScoreColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserPrecisionValueText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.UserPrecisionValue).TextValue
            ),
            rows.Select(row => row.Cells[new UserPrecisionValueColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserEdgeDateText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.UserEdgeDate).TextValue
            ),
            rows.Select(row => row.Cells[new UserEdgeDateColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserEdgeDateTimeText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.UserEdgeDateTime).TextValue
            ),
            rows.Select(row => row.Cells[new UserEdgeDateTimeColumn()].Value.TextValue)
        );
    }

    [Fact]
    public void MirrorsUserEdgeTimeText()
    {
        IRow[] rows = [.. new UsersTableDataSet()];
        UserRecord[] records = [.. new UserRecords()];

        Assert.Equal(
            records.Select(record =>
                new InvariantCellText(record.UserEdgeTime).TextValue
            ),
            rows.Select(row => row.Cells[new UserEdgeTimeColumn()].Value.TextValue)
        );
    }
}
