using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Genius.Controls.TreeView.Core;

namespace Genius.Controls.TreeView.DragDrop
{
    class TreeViewDataObject : DataObject
    {
        Node FNode;
        IDataObject FDataObject;
        DataObject FData;
        public TreeViewDataObject(object aData) :base ("GTV", aData)
        {
            FDataObject = aData as IDataObject;
            FNode = aData as Node;
            FData = aData as DataObject;
        }

        public override bool ContainsFileDropList()
        {
            if (FData != null)
                return FData.ContainsFileDropList();
            return base.ContainsFileDropList();
        }

        public override bool ContainsAudio()
        {
            if (FData != null)
                return FData.ContainsAudio();
            return base.ContainsAudio();
        }

        public override bool ContainsImage()
        {
            if (FData != null)
                return FData.ContainsImage();
            return base.ContainsImage();
        }

        public override bool ContainsText()
        {
            if (FData != null)
                return FData.ContainsText();
            return base.ContainsText();
        }

        public override bool ContainsText(TextDataFormat format)
        {
            if (FData != null)
                return FData.ContainsText(format);
            return base.ContainsText(format);
        }

        public override System.IO.Stream GetAudioStream()
        {
            if (FData != null)
                return FData.GetAudioStream();
            return base.GetAudioStream();
        }

        public override object GetData(string format)
        {
            if (FDataObject != null)
                return FDataObject.GetData(format);
            return base.GetData(format);
        }

        public override object GetData(string format, bool autoConvert)
        {
            if (FDataObject != null)
                return FDataObject.GetData(format, autoConvert);
            return base.GetData(format, autoConvert);
        }

        public override object GetData(Type format)
        {
            if (FDataObject != null)
                return FDataObject.GetData(format);
            return base.GetData(format);
        }

        public override bool GetDataPresent(string format)
        {
            if (FDataObject != null)
                return FDataObject.GetDataPresent(format);
            return base.GetDataPresent(format);
        }

        public override bool GetDataPresent(string format, bool autoConvert)
        {
            if (FDataObject != null)
                return FDataObject.GetDataPresent(format, autoConvert);
            return base.GetDataPresent(format, autoConvert);
        }

        public override bool GetDataPresent(Type format)
        {
            if (FDataObject != null)
                return FDataObject.GetDataPresent(format);
            return base.GetDataPresent(format);
        }

        public override System.Collections.Specialized.StringCollection GetFileDropList()
        {
            if (FData != null)
                return FData.GetFileDropList();
            return base.GetFileDropList();
        }

        public override string[] GetFormats()
        {
            if (FDataObject != null)
                return FDataObject.GetFormats();
            return base.GetFormats();
        }

        public override string[] GetFormats(bool autoConvert)
        {
            if (FDataObject != null)
                return FDataObject.GetFormats(autoConvert);
            return base.GetFormats(autoConvert);
        }

        public override System.Drawing.Image GetImage()
        {
            if (FData != null)
                return FData.GetImage();
            return base.GetImage();
        }

        public override string GetText()
        {
            if (FData != null)
                return FData.GetText();
            return base.GetText();
        }

        public override string GetText(TextDataFormat format)
        {
            if (FData != null)
                return FData.GetText(format);
            return base.GetText(format);
        }

        public override void SetAudio(byte[] audioBytes)
        {
            if (FData != null)
                FData.SetAudio(audioBytes);
            base.SetAudio(audioBytes);
        }

        public override void SetAudio(System.IO.Stream audioStream)
        {
            if (FData != null)
                FData.SetAudio(audioStream);
            base.SetAudio(audioStream);
        }

        public override void SetData(object data)
        {
            if (FDataObject != null)
                FDataObject.SetData(data);
            base.SetData(data);
        }

        public override void SetData(string format, bool autoConvert, object data)
        {
            if (FDataObject != null)
                FDataObject.SetData(format, autoConvert, data);
            base.SetData(format, autoConvert, data);
        }

        public override void SetData(string format, object data)
        {
            if (FDataObject != null)
                FDataObject.SetData(format, data);
            base.SetData(format, data);
        }

        public override void SetData(Type format, object data)
        {
            if (FDataObject != null)
                FDataObject.SetData(format, data);
            base.SetData(format, data);
        }

        public override void SetFileDropList(System.Collections.Specialized.StringCollection filePaths)
        {
            if (FData != null)
                FData.SetFileDropList(filePaths);
            base.SetFileDropList(filePaths);
        }

        public override void SetImage(System.Drawing.Image image)
        {
            if (FData != null)
                FData.SetImage(image);
            base.SetImage(image);
        }

        public override void SetText(string textData)
        {
            if (FData != null)
                FData.SetText(textData);
            base.SetText(textData);
        }

        public override void SetText(string textData, TextDataFormat format)
        {
            if (FData != null)
                FData.SetText(textData, format);
            base.SetText(textData, format);
        }
    }
}
