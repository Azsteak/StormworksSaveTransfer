   M S B A M L   `   `   `  ���� S  OStormworks Save Transfer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Stormworks_Save_TransferStormworks_Save_Transfer  )    #Stormworks_Save_Transfer.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Stormworks_Save_Transfer       � Title$  Stormworks Save Transfer��$	��450��$	��800�� � 	Resources    DefaultDataTemplate � ColumnDefinitions  BooleanDataTemplate ��Name d� 	IsChecked?   9Stormworks_Save_Transfer.SavePropertyDataTemplateSelector  templateSelector   DefaultDataTemplate   BooleanDataTemplate��%`  &	        &	 ~     &	 +    7   7  �� .R��� .+�� $��4q� �� �� .+��� $��0��$
��Bold"����� *Key+�� $��1��{�.  ���� *Value+�� .R��� .+�� $��4q� �� �� .+��� $��0��$
��Bold"����� *Key+�� $ checkBox��$��1��{�.  $��Center=����� *Value+ �� *Value+  8   8  .���  �� $	��27* ��� $	��73* �.+��� -    ��Name$ button��$��Open source save file��$��0,43,0,0q�$	��Top=�$��20��$��Center=�$	��136���� -    ��Name$ sourceFile_label��$��No file loaded��$��Center=�$��0,68,0,0q�$	��Top=�
���  ��$��26��$��84���� -   $ button1��$ ��Open destination save file��$��Center=�$��	0,125,0,0q�$	��Top=�$	��160��$��20���� -   $ destinationFile_label��$��No file loaded��$��Center=�$��	0,150,0,0q�$	��Top=�
���  ��$��26��$��84���� -   $ 
copyButton��$��Copy progression��{�.  $��Center=�$��	0,334,0,0q�$	��Top=�$��20��$	��104���� -   $ exportButton��$ ��Overwrite Destination file��{�.  $��Center=�$��	0,372,0,0q�$	��Top=�� $��1��$��0,0,0,19q� �� $��3* ��� $��1* ��� $��3* ��� $��1* �	 � RowDefinitions	 �� �� �� .+��� $��	Game Data��$
��Left=��� -   $ CopyGameData��$
��Copy��$	��Top=�$��1��$ FalseY�$��Center=�$��73���� -   
 ��Name$
 sourceGameData��#��[ 
���   �$��Stretch=�$��0 20 0 0q��� $��Difficulty Settings��$��1��$
��Left=��� -	   $ CopyDifficultySetting��$
��Copy��$	��Top=�$��Center=�$��1��$��1��$ FalseY��� -
   $
 sourceDifficultySetting��#��[ 
���   �$��1��$��Stretch=�$��0 20 0 0q��� $��Game Mode Settings��$��2��$
��Left=��� -   $ CopyGameModeSetting��$
��Copy��$	��Top=�$��Center=�$��1��$��2��$ FalseY��� -   $
 sourceGameModeSetting��#��[ 
���   �$��2��$��Stretch=�$��0 20 0 0q��� -    ��Name$ 	dataArrow��$��Center=�$��1��$��
/32213.png��$��Center=�$��73���� -   $ difficultyArrow��$��Center=�$��1��$��1��$��
/32213.png��$��Center=�$��73���� -   $ 	modeArrow��$��Center=�$��1��$��2��$��
/32213.png��$��Center=�$��73���� -   $
 destinationGameData��#��[ 
���   �$��2�� � IsSharedSizeScope . $��Stretch=�$��0 20 0 0q��� -   $"
 destinationDifficultySetting��#��[ 
���   �$��2��$��1��$��Stretch=�$��0 20 0 0q��� -   $ 
 destinationGameModeSetting��#��[ 
���   �$��2��$��2��$��Stretch=�$��0 20 0 0q�