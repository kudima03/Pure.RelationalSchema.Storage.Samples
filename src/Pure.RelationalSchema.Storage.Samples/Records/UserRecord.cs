namespace Pure.RelationalSchema.Storage.Samples.Records;

// Ground-truth mirror of a UsersTable row, as plain .NET values. A consumer
// computes an expected result from these instead of re-deriving it from the
// code under test; the cell text of the matching IRow sample is exactly what
// InvariantCellText renders for each value here.
public sealed record UserRecord(
    Guid UserId,
    Guid UserTenantId,
    string UserName,
    DateOnly SignupDate,
    bool UserActive,
    DateTime LastLogin,
    double UserAge,
    TimeOnly ShiftStart,
    double? UserScore,
    double UserPrecisionValue,
    DateOnly UserEdgeDate,
    DateTime UserEdgeDateTime,
    TimeOnly UserEdgeTime
);
