namespace MedDomain.Common.Query;

public class QueryPagination : FilterPagination
{
    public QueryPagination(uint pageSize, uint pageToken, bool asNoTracking) : base(pageSize, pageToken)
    {
        AsNoTracking = asNoTracking;
    }
    public bool AsNoTracking { get; set; }
}