namespace net_core_bootcamp_b1_mert.Helpers
{
    /// <summary>
    ///  Ilk 2 karakter ekran
    ///  3. Karakter mesaj türü (I:info, W:Warning, E:Error )
    ///  Son 2 karakter hatayı kodu
    /// </summary>
    public class ApiResultMessages
    {
        /// <summary>
        /// All Process Succesful
        /// </summary>
        public const string Ok = "Ok";

        #region HWEvent

        /// <summary>
        /// No Event Found 
        /// </summary>
        public const string HEE01 = "HEE01";

        #endregion
    }
}
