using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Enums
{


    public enum EM_AppResolution
    {

    }





    public enum EM_CameraType
    {
        DAHUA,
        ENSTER,
        HANSE,
        HIKVISION,
    }

    public enum EM_StreamType
    {
        MJPEG,
        PlayFile,
        LocalVideoCaptureDevice,
        JPEG,
        MPEG,
        MPEG4,
        H264,
        Onvif
    }

    public enum EM_Resolution
    {
        HD_1280x720,
        FullHD_1920x1080,
        QuadHD_2560x1440,
        UltraHD_3840_2160
    }

    public enum EM_SDK
    {
        KZTEK_SDK2,
        Dahua_SDK,
        Emgu_SDK
    }

}
