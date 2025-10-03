window.brotliDecompress = async (compressedData) => {
  return new TextDecoder().decode(BrotliDecode(compressedData));
}