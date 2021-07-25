# [Kingdom Hearts Union Cross]() - BGAD

### BGAD version

version 1: used by Final Fantasy All the Bravest
version 2: used by Kingdom Hearts Union Cross

no differences to the header at first glance.
they do use encryption 1 in version 1 and encryption 2 in version 2


### BGAD header

| Offset | Type   | Description |
|--------|--------|-------------|
| 0x0    | uint32 | Magic number
| 0x4    | uint16 | version (always 2 in KHUX)
| 0x6    | uint16 | IvType (is always 4 when encryption 3 is used)
| 0x8    | uint16 | Header size (always 24 even in v1 at first look)
| 0xA    | uint16 | Name size
| 0xC    | uint16 | Encryption
| 0xE    | uint16 | Compression
| 0x10   | uint32 | DataSize (compressed)
| 0x14   | uint32 | Decompressed size

### Encryption

0: not used in files but in code, no encryption
1: used in a few files in jp release (mostly used by bgad version 1), xor8b
2: xor32b
3: chacha8

### Compression

0: not compressed
1: unknown (is used by final fantasy)
2: zlib compression

