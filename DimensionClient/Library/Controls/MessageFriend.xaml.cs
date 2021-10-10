﻿using DimensionClient.Common;
using DimensionClient.Models;
using DimensionClient.Models.ResultModels;
using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DimensionClient.Library.Controls
{
    /// <summary>
    /// MessageFriend.xaml 的交互逻辑
    /// </summary>
    public partial class MessageFriend : UserControl
    {
        public MessageFriend()
        {
            InitializeComponent();
        }

        private void UserControlMain_Loaded(object sender, RoutedEventArgs e)
        {
            ChatMessagesModel chatMessages = DataContext as ChatMessagesModel;
            if (chatMessages.LoadFirst)
            {
                DoubleAnimation doubleAnimationScale = new()
                {
                    From = 0.6,
                    To = 1,
                    Duration = new TimeSpan(0, 0, 0, 0, 800),
                    EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
                };
                DoubleAnimation doubleAnimationY = new()
                {
                    From = 20,
                    To = 0,
                    Duration = new TimeSpan(0, 0, 0, 0, 800),
                    EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
                };
                DoubleAnimation doubleAnimationOpacity = new()
                {
                    From = 0,
                    To = 1,
                    Duration = new TimeSpan(0, 0, 0, 0, 800),
                    EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut }
                };
                stfLoaded.BeginAnimation(ScaleTransform.ScaleXProperty, doubleAnimationScale);
                stfLoaded.BeginAnimation(ScaleTransform.ScaleYProperty, doubleAnimationScale);
                ttfLoaded.BeginAnimation(TranslateTransform.YProperty, doubleAnimationY);
                BeginAnimation(OpacityProperty, doubleAnimationOpacity);
                chatMessages.LoadFirst = false;
            }
        }

        private void UserControlMain_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is ChatMessagesModel chatMessages)
            {
                imgHead.DataContext = chatMessages.SenderID;
                txbTime.Text = chatMessages.CreateTime.ToString("t", ClassHelper.cultureInfo);
                switch (chatMessages.MessageType)
                {
                    case ClassHelper.MessageType.Text:
                        txbContent.Visibility = Visibility.Visible;
                        txbContent.Text = chatMessages.MessageContent;
                        break;
                    case ClassHelper.MessageType.Voice:
                        break;
                    case ClassHelper.MessageType.File:
                        {
                            FileModel fileModel = JsonConvert.DeserializeObject<FileModel>(chatMessages.MessageContent);
                            switch (fileModel.FileType)
                            {
                                case ClassHelper.FileType.Image:
                                    if (fileModel.FileName.ToLower(ClassHelper.cultureInfo).Contains(".gif", StringComparison.CurrentCulture))
                                    {
                                        mdiContent.Visibility = Visibility.Visible;
                                        mdiContent.SetBinding(MediaElement.SourceProperty, new Binding { Converter = ClassHelper.FindResource<IValueConverter>("SourceOnlineConvert") });
                                        mdiContent.DataContext = fileModel.FileName;
                                    }
                                    else
                                    {
                                        imgContent.Visibility = Visibility.Visible;
                                        imgContent.SetBinding(Image.SourceProperty, new Binding { Converter = ClassHelper.FindResource<IValueConverter>("ImageSourceOnlineConvert"), ConverterParameter = 300 });
                                        imgContent.DataContext = fileModel.FileName;
                                    }
                                    break;
                                case ClassHelper.FileType.Word:
                                    break;
                                case ClassHelper.FileType.Excel:
                                    break;
                                case ClassHelper.FileType.PPT:
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case ClassHelper.MessageType.VoiceTalk:
                        break;
                    case ClassHelper.MessageType.VideoTalk:
                        break;
                    default:
                        break;
                }
            }
        }

        private void MdiContent_MediaEnded(object sender, RoutedEventArgs e)
        {
            mdiContent.Position = TimeSpan.FromMilliseconds(1);
            mdiContent.Play();
        }
    }
}
