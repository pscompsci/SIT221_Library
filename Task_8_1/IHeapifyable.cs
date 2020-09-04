namespace Task_8_1
{
    public interface IHeapifyable<K, D>
    {
        D Data { get; set; }
        K Key { get; }
        int Position { get; }
    }
}
