﻿using System.Runtime.InteropServices;

namespace System
{

    namespace AI
    {

        public static partial class imageio
        {

            internal static partial class StbImageSharp
            {

                unsafe partial class StbImage
                {

                    public static int[] stbi__zlength_base =
                    {
                        3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 17, 19, 23, 27, 31, 35, 43, 51, 59, 67, 83, 99, 115, 131, 163, 195,
                        227, 258, 0, 0
                    };

                    public static int[] stbi__zlength_extra =
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 0, 0, 0};

                    public static int[] stbi__zdist_base =
                    {
                        1, 2, 3, 4, 5, 7, 9, 13, 17, 25, 33, 49, 65, 97, 129, 193, 257, 385, 513, 769, 1025, 1537, 2049, 3073, 4097,
                        6145, 8193, 12289, 16385, 24577, 0, 0
                    };

                    public static int[] stbi__zdist_extra =
                    {0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13};

                    public static byte[] length_dezigzag = { 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };

                    public static byte[] stbi__zdefault_length =
                    {
                        8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
                        8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
                        8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
                        8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
                        9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
                        9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
                        9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
                        9, 9, 9, 9, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8
                    };

                    public static byte[] stbi__zdefault_distance =
                    {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};

                    public static int stbi__zbuild_huffman(stbi__zhuffman* z, byte* sizelist, int num)
                    {
                        var i = 0;
                        var k = 0;
                        var code = 0;
                        var next_code = stackalloc int[16];
                        var sizes = stackalloc int[17];
                        CRuntime.memset(sizes, 0, (ulong)sizeof(int));
                        CRuntime.memset(z->fast, 0, (ulong)((1 << 9) * sizeof(ushort)));
                        for(i = 0; i < num; ++i)
                        {
                            ++sizes[sizelist[i]];
                        }
                        sizes[0] = 0;
                        for(i = 1; i < 16; ++i)
                        {
                            if(sizes[i] > (1 << i))
                            {
                                return stbi__err("bad sizes");
                            }
                        }
                        code = 0;
                        for(i = 1; i < 16; ++i)
                        {
                            next_code[i] = code;
                            z -> firstcode[i] = (ushort)code;
                            z -> firstsymbol[i] = (ushort)k;
                            code = code + sizes[i];
                            if(sizes[i] != 0)
                            {
                                if((code - 1) >= (1 << i))
                                {
                                    return stbi__err("bad codelengths");
                                }
                            }
                            z -> maxcode[i] = code << (16 - i);
                            code <<= 1;
                            k += sizes[i];
                        }
                        z -> maxcode[16] = 0x10000;
                        for(i = 0; i < num; ++i)
                        {
                            var s = (int)sizelist[i];
                            if(s != 0)
                            {
                                var c = next_code[s] - z -> firstcode[s] + z-> firstsymbol[s];
                                var fastv = (ushort)((s << 9) | i);
                                z -> size[c] = (byte)s;
                                z -> value[c] = (ushort)i;
                                if(s <= 9)
                                {
                                    var j = stbi__bit_reverse(next_code[s], s);
                                    while(j < (1 << 9))
                                    {
                                        z -> fast[j] = fastv;
                                        j += 1 << s;
                                    }
                                }
                                ++next_code[s];
                            }
                        }
                        return 1;
                    }

                    public static byte stbi__zget8(stbi__zbuf* z)
                    {
                        if(z -> zbuffer >= z -> zbuffer_end)
                        {
                            return 0;
                        }
                        return *z -> zbuffer++;
                    }

                    public static void stbi__fill_bits(stbi__zbuf* z)
                    {
                        do
                        {
                            z -> code_buffer |= (uint)stbi__zget8(z) << z->num_bits;
                            z -> num_bits += 8;
                        }
                        while(z -> num_bits <= 24);
                    }

                    public static uint stbi__zreceive(stbi__zbuf* z, int n)
                    {
                        uint k = 0;
                        if(z -> num_bits < n)
                        {
                            stbi__fill_bits(z);
                        }
                        k = (uint)(z->code_buffer & ((1 << n) - 1));
                        z -> code_buffer >>= n;
                        z -> num_bits -= n;
                        return k;
                    }

                    public static int stbi__zhuffman_decode_slowpath(stbi__zbuf* a, stbi__zhuffman* z)
                    {
                        var b = 0;
                        var s = 0;
                        var k = 0;
                        k = stbi__bit_reverse((int)a->code_buffer, 16);
                        for(s = 9 + 1; ; ++s)
                        {
                            if(k < z -> maxcode[s])
                            {
                                break;
                            }
                        }
                        if(s == 16)
                        {
                            return -1;
                        }
                        b = (k >> (16 - s)) - z -> firstcode[s] + z -> firstsymbol[s];
                        a -> code_buffer >>= s;
                        a -> num_bits -= s;
                        return z -> value[b];
                    }

                    public static int stbi__zhuffman_decode(stbi__zbuf* a, stbi__zhuffman* z)
                    {
                        var b = 0;
                        var s = 0;
                        if(a -> num_bits < 16)
                        {
                            stbi__fill_bits(a);
                        }
                        b = z -> fast[a -> code_buffer & ((1 << 9) - 1)];
                        if(b != 0)
                        {
                            s = b >> 9;
                            a -> code_buffer >>= s;
                            a -> num_bits -= s;
                            return b & 511;
                        }
                        return stbi__zhuffman_decode_slowpath(a, z);
                    }

                    public static int stbi__zexpand(stbi__zbuf* z, sbyte* zout, int n)
                    {
                        sbyte* q;
                        var cur = 0;
                        var limit = 0;
                        var old_limit = 0;
                        z -> zout = zout;
                        if(z -> z_expandable == 0)
                        {
                            return stbi__err("output buffer limit");
                        }
                        cur = (int)(z -> zout - z -> zout_start);
                        limit = old_limit = (int)(z -> zout_end - z -> zout_start);
                        while(cur + n > limit)
                        {
                            limit *= 2;
                        }
                        q = (sbyte*)CRuntime.realloc(z -> zout_start, (ulong)limit);
                        if(q == null)
                        {
                            return stbi__err("outofmem");
                        }
                        z -> zout_start = q;
                        z -> zout = q + cur;
                        z -> zout_end = q + limit;
                        return 1;
                    }

                    public static int stbi__parse_huffman_block(stbi__zbuf* a)
                    {
                        var zout = a->zout;
                        for(; ; )
                        {
                            var z = stbi__zhuffman_decode(a, &a -> z_length);
                            if(z < 256)
                            {
                                if(z < 0)
                                {
                                    return stbi__err("bad huffman code");
                                }
                                if(zout >= a -> zout_end)
                                {
                                    if(stbi__zexpand(a, zout, 1) == 0)
                                    {
                                        return 0;
                                    }
                                    zout = a -> zout;
                                }
                                *zout++ = (sbyte)z;
                            }
                            else
                            {
                                byte* p;
                                var len = 0;
                                var dist = 0;
                                if(z == 256)
                                {
                                    a -> zout = zout;
                                    return 1;
                                }
                                z -= 257;
                                len = stbi__zlength_base[z];
                                if(stbi__zlength_extra[z] != 0)
                                {
                                    len += (int)stbi__zreceive(a, stbi__zlength_extra[z]);
                                }
                                z = stbi__zhuffman_decode(a, &a->z_distance);
                                if(z < 0)
                                {
                                    return stbi__err("bad huffman code");
                                }
                                dist = stbi__zdist_base[z];
                                if(stbi__zdist_extra[z] != 0)
                                {
                                    dist += (int)stbi__zreceive(a, stbi__zdist_extra[z]);
                                }
                                if((zout - a -> zout_start) < dist)
                                {
                                    return stbi__err("bad dist");
                                }
                                if((zout + len) > a -> zout_end)
                                {
                                    if(stbi__zexpand(a, zout, len) == 0)
                                    {
                                        return 0;
                                    }
                                    zout = a -> zout;
                                }
                                p = (byte*)(zout - dist);
                                if(dist == 1)
                                {
                                    var v = *p;
                                    if(len != 0)
                                    {
                                        do
                                        {
                                            *zout++ = (sbyte)v;
                                        }
                                        while(--len != 0);
                                    }
                                }
                                else
                                {
                                    if(len != 0)
                                    {
                                        do
                                        {
                                            *zout++ = (sbyte)*p++;
                                        }
                                        while(--len != 0);
                                    }
                                }
                            }
                        }
                    }

                    public static int stbi__compute_huffman_codes(stbi__zbuf* a)
                    {
                        var z_codelength = new stbi__zhuffman();
                        var lencodes = stackalloc byte[286 + 32 + 137];
                        var codelength_sizes = stackalloc byte[19];
                        var i = 0;
                        var n = 0;
                        var hlit = (int)(stbi__zreceive(a, 5) + 257);
                        var hdist = (int)(stbi__zreceive(a, 5) + 1);
                        var hclen = (int)(stbi__zreceive(a, 4) + 4);
                        var ntot = hlit + hdist;
                        CRuntime.memset(codelength_sizes, 0, (ulong)(19 * sizeof(byte)));
                        for(i = 0; i < hclen; ++i)
                        {
                            var s = (int)stbi__zreceive(a, 3);
                            codelength_sizes[length_dezigzag[i]] = (byte)s;
                        }
                        if(stbi__zbuild_huffman(&z_codelength, codelength_sizes, 19) == 0)
                        {
                            return 0;
                        }
                        n = 0;
                        while(n < ntot)
                        {
                            var c = stbi__zhuffman_decode(a, &z_codelength);
                            if((c < 0) || (c >= 19))
                            {
                                return stbi__err("bad codelengths");
                            }
                            if(c < 16)
                            {
                                lencodes[n++] = (byte)c;
                            }
                            else
                            {
                                var fill = (byte)0;
                                if(c == 16)
                                {
                                    c = (int)(stbi__zreceive(a, 2) + 3);
                                    if(n == 0)
                                    {
                                        return stbi__err("bad codelengths");
                                    }
                                    fill = lencodes[n - 1];
                                }
                                else
                                {
                                    if(c == 17)
                                    {
                                        c = (int)(stbi__zreceive(a, 3) + 3);
                                    }
                                    else
                                    {
                                        c = (int)(stbi__zreceive(a, 7) + 11);
                                    }
                                }
                                if((ntot - n) < c)
                                {
                                    return stbi__err("bad codelengths");
                                }
                                CRuntime.memset(lencodes + n, fill, (ulong)c);
                                n += c;
                            }
                        }
                        if(n != ntot)
                        {
                            return stbi__err("bad codelengths");
                        }
                        if(stbi__zbuild_huffman(&a -> z_length, lencodes, hlit) == 0)
                        {
                            return 0;
                        }
                        if(stbi__zbuild_huffman(&a -> z_distance, lencodes + hlit, hdist) == 0)
                        {
                            return 0;
                        }
                        return 1;
                    }

                    public static int stbi__parse_uncompressed_block(stbi__zbuf* a)
                    {
                        var header = stackalloc byte[4];
                        var len = 0;
                        var nlen = 0;
                        var k = 0;
                        if((a -> num_bits & 7) != 0)
                        {
                            stbi__zreceive(a, a -> num_bits & 7);
                        }
                        k = 0;
                        while(a -> num_bits > 0)
                        {
                            header[k++] = (byte)(a -> code_buffer & 255);
                            a -> code_buffer >>= 8;
                            a -> num_bits -= 8;
                        }
                        while(k < 4)
                        {
                            header[k++] = stbi__zget8(a);
                        }
                        len = header[1] * 256 + header[0];
                        nlen = header[3] * 256 + header[2];
                        if(nlen != (len ^ 0xffff))
                        {
                            return stbi__err("zlib corrupt");
                        }
                        if((a -> zbuffer + len) > a -> zbuffer_end)
                        {
                            return stbi__err("read past buffer");
                        }
                        if((a -> zout + len) > a -> zout_end)
                        {
                            if(stbi__zexpand(a, a -> zout, len) == 0)
                            {
                                return 0;
                            }
                        }
                        CRuntime.memcpy(a -> zout, a -> zbuffer, (ulong)len);
                        a -> zbuffer += len;
                        a -> zout += len;
                        return 1;
                    }

                    public static int stbi__parse_zlib_header(stbi__zbuf* a)
                    {
                        var cmf = (int)stbi__zget8(a);
                        var cm = cmf & 15;
                        var flg = (int)stbi__zget8(a);
                        if((cmf * 256 + flg) % 31 != 0)
                        {
                            return stbi__err("bad zlib header");
                        }
                        if((flg & 32) != 0)
                        {
                            return stbi__err("no preset dict");
                        }
                        if(cm != 8)
                        {
                            return stbi__err("bad compression");
                        }
                        return 1;
                    }

                    public static int stbi__parse_zlib(stbi__zbuf* a, int parse_header)
                    {
                        var final = 0;
                        var type = 0;
                        if(parse_header != 0)
                        {
                            if(stbi__parse_zlib_header(a) == 0)
                            {
                                return 0;
                            }
                        }
                        a -> num_bits = 0;
                        a -> code_buffer = 0;
                        do
                        {
                            final = (int)stbi__zreceive(a, 1);
                            type = (int)stbi__zreceive(a, 2);
                            if(type == 0)
                            {
                                if(stbi__parse_uncompressed_block(a) == 0)
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                if(type == 3)
                                {
                                    return 0;
                                }
                                else
                                {
                                    if(type == 1)
                                    {
                                        fixed(byte* b = stbi__zdefault_length)
                                        {
                                            if(stbi__zbuild_huffman(&a -> z_length, b, 288) == 0)
                                            {
                                                return 0;
                                            }
                                        }
                                        fixed(byte* b = stbi__zdefault_distance)
                                        {
                                            if(stbi__zbuild_huffman(&a -> z_distance, b, 32) == 0)
                                            {
                                                return 0;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if(stbi__compute_huffman_codes(a) == 0)
                                        {
                                            return 0;
                                        }
                                    }
                                    if(stbi__parse_huffman_block(a) == 0)
                                    {
                                        return 0;
                                    }
                                }
                            }
                        }
                        while(final == 0);
                        return 1;
                    }

                    public static int stbi__do_zlib(stbi__zbuf* a, sbyte* obuf, int olen, int exp, int parse_header)
                    {
                        a -> zout_start = obuf;
                        a -> zout = obuf;
                        a -> zout_end = obuf + olen;
                        a -> z_expandable = exp;
                        return stbi__parse_zlib(a, parse_header);
                    }

                    public static sbyte* stbi_zlib_decode_malloc_guesssize(sbyte* buffer, int len, int initial_size, int* outlen)
                    {
                        var a = new stbi__zbuf();
                        var p = (sbyte*)stbi__malloc((ulong)initial_size);
                        if(p == null)
                        {
                            return null;
                        }
                        a.zbuffer = (byte*)buffer;
                        a.zbuffer_end = (byte*)buffer + len;
                        if(stbi__do_zlib(&a, p, initial_size, 1, 1) != 0)
                        {
                            if(outlen != null)
                            {
                                *outlen = (int)(a.zout - a.zout_start);
                            }
                            return a.zout_start;
                        }
                        CRuntime.free(a.zout_start);
                        return null;
                    }

                    public static sbyte* stbi_zlib_decode_malloc(sbyte* buffer, int len, int* outlen)
                    {
                        return stbi_zlib_decode_malloc_guesssize(buffer, len, 16384, outlen);
                    }

                    public static sbyte* stbi_zlib_decode_malloc_guesssize_headerflag(sbyte* buffer, int len, int initial_size, int* outlen, int parse_header)
                    {
                        var a = new stbi__zbuf();
                        var p = (sbyte*)stbi__malloc((ulong)initial_size);
                        if(p == null)
                        {
                            return null;
                        }
                        a.zbuffer = (byte*)buffer;
                        a.zbuffer_end = (byte*)buffer + len;
                        if(stbi__do_zlib(&a, p, initial_size, 1, parse_header) != 0)
                        {
                            if(outlen != null)
                            {
                                *outlen = (int)(a.zout - a.zout_start);
                            }
                            return a.zout_start;
                        }
                        CRuntime.free(a.zout_start);
                        return null;
                    }

                    public static int stbi_zlib_decode_buffer(sbyte* obuffer, int olen, sbyte* ibuffer, int ilen)
                    {
                        var a = new stbi__zbuf();
                        a.zbuffer = (byte*)ibuffer;
                        a.zbuffer_end = (byte*)ibuffer + ilen;
                        if(stbi__do_zlib(&a, obuffer, olen, 0, 1) != 0)
                        {
                            return (int)(a.zout - a.zout_start);
                        }
                        return -1;
                    }

                    public static sbyte* stbi_zlib_decode_noheader_malloc(sbyte* buffer, int len, int* outlen)
                    {
                        var a = new stbi__zbuf();
                        var p = (sbyte*)stbi__malloc((ulong)16384);
                        if(p == null)
                        {
                            return null;
                        }
                        a.zbuffer = (byte*)buffer;
                        a.zbuffer_end = (byte*)buffer + len;
                        if(stbi__do_zlib(&a, p, 16384, 1, 0) != 0)
                        {
                            if(outlen != null)
                            {
                                *outlen = (int)(a.zout - a.zout_start);
                            }
                            return a.zout_start;
                        }
                        CRuntime.free(a.zout_start);
                        return null;
                    }

                    public static int stbi_zlib_decode_noheader_buffer(sbyte* obuffer, int olen, sbyte* ibuffer, int ilen)
                    {
                        var a = new stbi__zbuf();
                        a.zbuffer = (byte*)ibuffer;
                        a.zbuffer_end = (byte*)ibuffer + ilen;
                        if(stbi__do_zlib(&a, obuffer, olen, 0, 0) != 0)
                        {
                            return (int)(a.zout - a.zout_start);
                        }
                        return -1;
                    }

                    [StructLayout(LayoutKind.Sequential)]
                    public struct stbi__zhuffman
                    {

                        public fixed ushort fast[1 << 9];

                        public fixed ushort firstcode[16];

                        public fixed int maxcode[17];

                        public fixed ushort firstsymbol[16];

                        public fixed byte size[288];

                        public fixed ushort value[288];

                    }

                    [StructLayout(LayoutKind.Sequential)]
                    public struct stbi__zbuf
                    {

                        public byte* zbuffer;

                        public byte* zbuffer_end;

                        public int num_bits;

                        public uint code_buffer;

                        public sbyte* zout;

                        public sbyte* zout_start;

                        public sbyte* zout_end;

                        public int z_expandable;

                        public stbi__zhuffman z_length;

                        public stbi__zhuffman z_distance;

                    }

                }

            }

        }

    }

}