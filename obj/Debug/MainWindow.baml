   M S B A M L   `   `   `  ����S  OStormworks Save Transfer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Stormworks_Save_TransferStormworks_Save_Transfer  5   	   )    #Stormworks_Save_Transfer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Stormworks_Save_Transfer     5   	     � Title$  Stormworks Save Transfer��5   	   $	��450��6*   $	��800��67    � 	Resources 5	         DefaultDataTemplate � ColumnDefinitions  BooleanDataTemplate ��Name d� 	IsChecked?   9Stormworks_Save_Transfer.SavePropertyDataTemplateSelector  templateSelector   DefaultDataTemplate   BooleanDataTemplate��%�  &	        &	     &	 d    7   7  �� 5
   
   .R�5      �� .+�5      � $��4q�6    5      �� 5      6-   �� 5      6-   .+�5      �� $��0��6   $
��Bold"�6D   ��6,   �� *Key+6X   �� 5      $��1��6   {�.  ��6.   �� *Value+6Y   5      5      5      �� 5   
   .R�5      �� .+�5      � $��4q�6    5      �� 5      6-   �� 5      6-   .+�5      �� $��0��6   $
��Bold"�6D   ��6,   �� *Key+6X   �� 5      $ checkBox��6/   $��1��6   {�.  $��Center=�6�   ��6A   �� *Value+ 6[   �� *Value+6�   5      5       5!        5#   
   8   8  5&   4   5'      .��5(      �  5)   
   �� 5*      $	��27* �6   �� 5+      $	��73* �6   .+�5-   
   �� -   5         ��Name$ button��5-      $��Open source save file��6!   $��0,43,0,0q�6A   $	��Top=�6S   $��20��6�   $��Center=�6�   $	��136��6�   �� 5.   
   -   5         ��Name$ sourceFile_label��5.      $��No file loaded��6*   $��Center=�6C   $��0,68,0,0q�6`   $	��Top=�6r   
���  ��$��26��6�   $��84��6�   �� 50   
   -   5        $ button1��50      $ ��Open destination save file��6"   $��Center=�6G   $��	0,125,0,0q�6�   $	��Top=�6�   $	��160��6�   $��20��6�   �� 51   
   -   5        $ destinationFile_label��51      $��No file loaded��6/   $��Center=�6H   $��	0,150,0,0q�6e   $	��Top=�6x   
���  ��$��26��6�   $��84��6�   �� 53   
   -   5        $ 
copyButton��53      $��Copy progression��6%   {�.  $��Center=�6R   $��	0,334,0,0q�6o   $	��Top=�6�   $��20��6�   $	��104��6�   6�   �� 54   
   -   5        $ exportButton��54      $ ��Overwrite Destination file��6'   {�.  $��Center=�6_   $��	0,372,0,0q�6|   $	��Top=�6�   6�   � 56   
   $��1��6   $��0,0,0,19q�6    57      �� 58      $��3* �6#   60   �� 59      $��1* �6#   60   �� 5:      $��3* �6#   60   �� 5;      $��1* �6#   60   	 � RowDefinitions	 5=      �� 5>      6#   �� 5?      6"   �� 5@      6"   .+�5B      �� $��	Game Data��6   $
��Left=�6(   6E   �� 5C      -   5        $ CopyGameData��5C      $
��Copy��6-   $	��Top=�6<   $��1��6T   $ FalseY�6d   $��Center=�6�   $��73��6�   �� 5D      -   5        
 ��Name$
 sourceGameData��5D   O   #��[ 6   
���   �$��Stretch=�6{   $��0 20 0 0q�6�   6�   �� 5E      $��Difficulty Settings��6   $��1��62   $
��Left=�6?   6\   �� 5F      -	   5        $ CopyDifficultySetting��5F      $
��Copy��66   $	��Top=�6E   $��Center=�6]   $��1��6z   $��1��6�   $ FalseY�6�   6�   �� 5G      -
   5        $
 sourceDifficultySetting��5G   O   #��[ 6   
���   �$��1��6�   $��Stretch=�6�   $��0 20 0 0q�6�   6�   �� 5H      $��Game Mode Settings��6   $��2��61   $
��Left=�6>   6[   �� 5I      -   5        $ CopyGameModeSetting��5I      $
��Copy��64   $	��Top=�6C   $��Center=�6[   $��1��6x   $��2��6�   $ FalseY�6�   6�   �� 5J      -   5        $
 sourceGameModeSetting��5J   O   #��[ 6   
���   �$��2��6�   $��Stretch=�6�   $��0 20 0 0q�6�   6�   �� 5L      -   5         ��Name$ 	dataArrow��5L      $��Center=�6)   $��1��6D   $��
/32213.png��6T   $��Center=�6h   $��73��6�   �� 5M      -   5        $ difficultyArrow��5M      $��Center=�6/   $��1��6J   $��1��6Z   $��
/32213.png��6g   $��Center=�6{   $��73��6�   �� 5N      -   5        $ 	modeArrow��5N      $��Center=�6)   $��1��6D   $��2��6T   $��
/32213.png��6a   $��Center=�6u   $��73��6�   �� 5Q      -   5        $
 destinationGameData��5Q   O   #��[ 6   
���   �$��2��6�    � IsSharedSizeScope . $��Stretch=�6�   $��0 20 0 0q�6�   6�   �� 5R      -   5        $"
 destinationDifficultySetting��5R   O   #��[ 6   
���   �$��2��6�   $��1��6�   $��Stretch=�6�   $��0 20 0 0q�6�   6�   �� 5S      -   5        $ 
 destinationGameModeSetting��5S   O   #��[ 6   
���   �$��2��6�   $��2��6�   $��Stretch=�6�   $��0 20 0 0q�6�   6�   5T      5W      5X      