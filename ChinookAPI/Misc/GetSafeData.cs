using Microsoft.Data.SqlClient;

namespace ChinookAPI.Misc
{
    
    public static class GetSafeData
    {
        // Safe string fetching. Found on Stackoverflow https://stackoverflow.com/a/1772037
        /// <summary>
        /// Safely fetches string from SqlDataReader. Returns empty string column is null.
        /// </summary>
        /// <returns>Empty string or column value</returns>
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}
