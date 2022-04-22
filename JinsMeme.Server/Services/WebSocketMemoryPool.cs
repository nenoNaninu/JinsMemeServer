using System;

namespace JinsMemeShard.Services;

public class WebSocketMemoryPool
{
    private byte[] _memoryPool;
    private int _offset = 0;

    private readonly int _margin;

    public int Offset
    {
        get => _offset;
        set
        {
            _offset = value;

            if (_offset + _margin <= _memoryPool.Length)
            {
                return;
            }

            var newArrayPool = new byte[_memoryPool.Length * 2];
            Buffer.BlockCopy(_memoryPool, 0, newArrayPool, 0, _offset);
            _memoryPool = newArrayPool;
        }
    }

    public WebSocketMemoryPool(int initialSize, int margin)
    {
        _memoryPool = new byte[initialSize];
        _margin = margin;
    }

    public Memory<byte> SliceFromOffset() => new Memory<byte>(_memoryPool, _offset, _memoryPool.Length - _offset);

    public byte[] ToArray()
    {
        var array = new byte[_offset];
        Buffer.BlockCopy(_memoryPool, 0, array, 0, _offset);
        return array;
    }
}