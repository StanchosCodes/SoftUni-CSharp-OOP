namespace P01.Stream_Progress
{
    public interface IResult
    {
        int BytesSent { get; }
        int Length { get; }
    }
}
