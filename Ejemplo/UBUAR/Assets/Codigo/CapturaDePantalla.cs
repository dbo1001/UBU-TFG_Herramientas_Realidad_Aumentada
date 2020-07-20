using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CapturaDePantalla : MonoBehaviour
{
    
    public GameObject disparador;

    public void ButtonScreenShot()
    {
        StartCoroutine("ScreenShot");

    }

    private IEnumerator ScreenShot()
    {
        yield return new WaitForEndOfFrame();

        string FileName = "CapturaDePantalla_PlantTest" + System.DateTime.Now.ToFileTime().ToString()+".png";
        string DefaultLocation = Application.persistentDataPath + "/" + FileName;
        string FolderLocation = "/storage/emulated/0/DCIM/UnityCAMERA/";
        string ScreenshotLocation = FolderLocation + FileName;

        //Compruevo si existe la carpeta destino.
        if (!System.IO.Directory.Exists(FolderLocation))
        {
            System.IO.Directory.CreateDirectory(FolderLocation);
        }

        //Realizo la captura de pantalla
        ScreenCapture.CaptureScreenshot(FileName);
        

        yield return new WaitForSeconds(1);
        //Muevo la captura de la raiz a la carpeta destino.
        System.IO.File.Move(DefaultLocation, ScreenshotLocation);
        
        

    }
}
