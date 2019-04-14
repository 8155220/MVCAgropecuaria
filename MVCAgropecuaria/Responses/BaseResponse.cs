using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.Responses
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Error { get; set; }

        private ResponseCodeEnum ResponseCode { get; set; }

        public void SetResponse(ResponseCodeEnum code)
        {
            ResponseCode = code;
        }

        public bool IsSuccess()
        {
            return ResponseCode == ResponseCodeEnum.Success;
        }

        public bool IsError()
        {
            return ResponseCode == ResponseCodeEnum.Error;
        }
        public bool IsNotFound()
        {
            return ResponseCode == ResponseCodeEnum.Error;
        }

        public bool IsInvalid()
        {
            return ResponseCode == ResponseCodeEnum.Invalid;
        }

        public bool IsExpired()
        {
            return ResponseCode == ResponseCodeEnum.Expired;
        }

        public bool IsAdvertisement()
        {
            return ResponseCode == ResponseCodeEnum.Advertisement;
        }
    }

    /// <summary>
    /// Enumerable que representa el tipo de respuesta procesado
    /// de acuerdo a la solicitud procesada.
    /// </summary>
    public enum ResponseCodeEnum
    {
        ///<summary> Todo fue procesado sin problema</summary>
        Success,
        /// <summary>Error al procesar la peticion</summary>
        Error,
        ///<summary> No se encontro resultados relacionado a la peticion </summary>
        NotFound,
        /// <summary> Error por datos no validos </summary>
        Invalid,
        /// <summary> Expiro la sesion o los datos temporales guardados en sesion </summary>
        Expired,
        /// <summary> Todo se dio sin ningun problema pero se ha generado una advertencia para tomarse en cuenta </summary>
        Advertisement
    }
}