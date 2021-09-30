using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class ProgressMgrPanel : MonoBehaviour
{
    public static FileOperationType OperationType = 0;
    public Text title;
    public Button button1, button2, button3;
    public MessageBoxPanel mesPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Close() 
    {
        gameObject.SetActive(false);
    }

    public void OpenProgressMgrPanel(FileOperationType operationType)
    {
        // Debug.Log("OpenProgressMgrPanel");
        if (operationType == FileOperationType.Save)
        {
            Debug.Log("OpenProgressMgrPanel Save");
            title.text = "请选择保存存档";
            UpdateStoredProgressMsg();
            // GameObject.Find("Title").GetComponent<Text>().text = "请选择保存存档位置";
            gameObject.SetActive(true);
        }
        else if (operationType == FileOperationType.Load)
        {
            Debug.Log("OpenProgressMgrPanel Load");
            // gameObject.GetComponent<Text>().text = "请选择读取存档位置"; 
            title.text = "请选择读取存档";

            UpdateStoredProgressMsg();

            gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("FileOperationType Error");
        }

        OperationType = operationType;
    }

    public void Process(int idx)
    {
        string file = Path.Combine(Globle.progressPath, "data" + idx.ToString());

        // Debug.Log("OpenProgressMgrPanel");
        if ((FileOperationType)ProgressMgrPanel.OperationType == FileOperationType.Save)
        {
            Debug.Log("Save2File:" + file);
            string s = "feawafewfewegtewqggerqgtewafdsfewagerwhg";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            _SaveBytes(file, bytes, s.Length);
            UpdateStoredProgressMsg();
        }
        else if ((FileOperationType)ProgressMgrPanel.OperationType == FileOperationType.Load)
        {
            Debug.Log("Load File:" + file);
            _LoadBytes(file);
        }
        else
        {
            Debug.Log("FileOperationType Error");
        }
    }

    private void _SaveBytes(string file, byte[] bytes, int len)
    {
        try
        {
            FileStream stream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            stream.Write(bytes, 0, len);
            stream.Close();
            stream.Dispose();
            Debug.Log("Save Success:" + System.Text.Encoding.UTF8.GetString(bytes, 0, len));
            //UnityEditor.EditorUtility.DisplayDialog("提示", "保存进度成功", "确认", "取消");
            mesPanel.Show("保存进度成功");
        }
        catch (System.Exception ex)
        {
            Debug.Log("Save Error:" + ex.Message);
            //UnityEditor.EditorUtility.DisplayDialog("提示", "写入文件错误", "确认", "取消");
            mesPanel.Show("写入文件错误");

        }
    }

    private byte[] _LoadBytes(string file)
    {
        try
        {
            FileStream stream = new FileInfo(file).OpenRead();
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, System.Convert.ToInt32(stream.Length));
            stream.Close();
            stream.Dispose();
            Debug.Log("Load Success:" + System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length));
            // bool ret = UnityEditor.EditorUtility.DisplayDialog("提示", "加载进度成功", "进入游戏", "取消");
            //bool ret = mesPanel.Show("加载进度成功", "进入游戏", "取消");
            //Debug.Log(ret);
            // 加载场景
            //if (ret)
            //   SceneManager.LoadScene("VideoScene");
            //else
            //    gameObject.SetActive(false);
            SceneManager.LoadScene("VideoScene");
            return buffer;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Load Error:" + ex.Message);
            //bool ret = UnityEditor.EditorUtility.DisplayDialog("提示", "该存档不存在", "确认", "取消");
            mesPanel.Show("该存档不存在");
            //Debug.Log(ret);
            //if (!ret)
            //  gameObject.SetActive(false);
        }
        return null;
    }

    private string GetFileTimeTips(string file)
    {
        try
        {
            if(!File.Exists(file))
                return "(不存在)";
            FileInfo fi = new FileInfo(file);
            Debug.Log(fi.LastWriteTime.ToString());
            return "(" + fi.LastWriteTime.ToString() + ")";     // 最后修改时间
        }
        catch (System.Exception ex)
        {
            Debug.Log("GetFile Error:" + ex.Message);
            return "(出错)";
        }
    }

    private void UpdateStoredProgressMsg()
    {
        try
        {
            if (!Directory.Exists(Globle.progressPath))//如果不存在就创建file文件夹　　             　　              
                Directory.CreateDirectory(Globle.progressPath);//创建该文件夹　　      
        }
        catch (System.Exception ex)
        {
            Debug.Log("CreateDirectory:" + ex.Message);
        }

        string file1 = Path.Combine(Globle.progressPath, "data1");
        string file2 = Path.Combine(Globle.progressPath, "data2");
        string file3 = Path.Combine(Globle.progressPath, "data3");

        button1.transform.Find("Text").GetComponent<Text>().text = "存档1" + GetFileTimeTips(file1);
        button2.transform.Find("Text").GetComponent<Text>().text = "存档2" + GetFileTimeTips(file2);
        button3.transform.Find("Text").GetComponent<Text>().text = "存档3" + GetFileTimeTips(file3);
    }
}
