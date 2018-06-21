namespace XF.Contatos.API
{   
    public interface ITakePhoto
    {
        void GetPhotoFromCamera();
    }

    public static class PhotoConstant
    {
        public static readonly int REQUEST_CAMERA = 1000;
    }
}
