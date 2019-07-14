﻿using System.Collections.Generic;

using ASSLibrary;

namespace WhoIsDemo.model
{

    public sealed class HeapAipuVideo
    {
        #region variables
        private List<Aipu> listAipuVideo = new List<Aipu>();
        private List<AipuObserver> listObserver = new List<AipuObserver>();
        private static readonly HeapAipuVideo instance = new HeapAipuVideo();

        public static HeapAipuVideo Instance => instance;
        #endregion

        #region methods

        public HeapAipuVideo()
        {

        }

        public int CreateFlowVideo()
        {
            Aipu aipu = new Aipu();
            listAipuVideo.Add(aipu);
            AipuObserver aipuObserver = new AipuObserver(aipu);
            listObserver.Add(aipuObserver);            
            return listAipuVideo.Count - 1;
        }

        public void LoadConfiguration(int indexVideo, string nameFile)
        {
            if(indexVideo < listAipuVideo.Count && indexVideo > -1)
            {
                listAipuVideo[indexVideo].LoadConfiguration(nameFile);
            }
        }

        public void InitLibrary(int indexVideo)
        {
            if (indexVideo < listAipuVideo.Count && indexVideo > -1)
            {
                listAipuVideo[indexVideo].InitLibrary();
            }

        }

  
        public void SetWorkMode(int indexVideo, int mode)
        {
            if (indexVideo < listAipuVideo.Count && indexVideo > -1)
            {
                listAipuVideo[indexVideo].SetWorkMode(mode);
            }

        }

        public void SetFrame(int indexVideo, byte[] data, int rows, int cols)
        {
            if (indexVideo < listAipuVideo.Count && indexVideo > -1)
            {
                listAipuVideo[indexVideo].SetFrame(data, rows, cols);
            }

        }

        public AipuObserver GetObserver(int indexVideo)
        {
            if (indexVideo < listAipuVideo.Count && indexVideo > -1)
            {
                return listObserver[indexVideo];
            }
            return null;
        }

        public Aipu GetAipuVideo(int indexVideo)
        {
            if (indexVideo < listAipuVideo.Count && indexVideo > -1)
            {
                return listAipuVideo[indexVideo];
            }
            return null;
        }

        public int CountVideo()
        {
            return listAipuVideo.Count;
        }

        public void RemoveVideo(int indexVideo)
        {
            if (indexVideo < listAipuVideo.Count && indexVideo > -1)
            {
                listAipuVideo[indexVideo].Dispose();
                listObserver[indexVideo].Dispose();
                listAipuVideo.RemoveAt(indexVideo);
                listObserver.RemoveAt(indexVideo);
            }
        }
        #endregion
    }
}
