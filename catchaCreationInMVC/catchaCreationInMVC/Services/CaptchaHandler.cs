﻿using catchaCreationInMVC.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace catchaCreationInMVC.Services
{
    public class CaptchaHandler:IDisposable
    {
        

        public void GenerateImage()
        {
            using (Bitmap objBMP = new Bitmap(60, 20))
            { 
                using (Graphics objGraphics = Graphics.FromImage(objBMP))
                {
                    objGraphics.Clear(Color.Green);
                    objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    using (Font objFont = new Font("Arial", 8, FontStyle.Bold))
                    {
                        string randomStr = string.Empty;
                        int[] myIntArray = new int[5];
                        Random autoRand = new Random();
                        for (var x = 0; x < 5; x++)
                        {
                            myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                            randomStr += (myIntArray[x].ToString());
                        }

                        HttpContext.Current.Session[InfraCons.CaptchaSessionKey] = randomStr;
                        objGraphics.DrawString(randomStr, objFont, Brushes.White, 3, 3);

                        HttpContext.Current.Response.ContentType = "image/GIF";
                        objBMP.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Gif);
                    }
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CaptchaHandler() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}