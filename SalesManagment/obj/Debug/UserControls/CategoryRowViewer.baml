   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5      &     SalesManagment.CategoryRowViewer   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SalesManagment     5      .��5
      �� ��5   
   �� 5        �� 
TargetType"  ��6   .�5      ��  �� Property � �� �� Value
 ���� 6/   �� 5       � �� 5      �� 5       �� 
TargetType" ��6*    � 	Resources 5         
MouseEnter  LightWhiteColor	 �� To �� From g� Duration �� 
TargetName	 �� TargetProperty  
MouseLeave��%J  &	        7  &	 �     7  �� 5   "   .��5   &   �� 8   $ TransparentX�5   5   $ 0:0:0.5D�5   5   $ 
MainBorder��5   5   $	 Background.Color�5   5   5   #   �� 5   "   .��5   &   �� $ TransparentX�65   8   $ 0:0:0.5D�5   5   $ 
MainBorder��5   5   $	 Background.Color�5    5   5!   #   5"      .R�5%      � 
 �Name$
 
MainBorder��6#   #��z��67    � ColumnDefinitions 5&   "   �� 5'   &   �� 5(   &   $��2* �67   �� 5)   &   $	��515 �67   .+�5-   "   �� $��0��6)     BackgroundVeryLightBrush#��[ 5.   )   $��0 2 2 2q�5/   )   $��50��50   )   ._�52   &   � .+�54   *   ��   ForegroundLightBrush#��[ 55   4     FontSizeSmall#��[ 56   4   $��Center=�57   4   $��Center=�58   4   ��54   4   �� *ID+ �� FallbackValue$ ID��58   4   5:   '   5<   #   �� 5?   "   $��1��6)   #��[ 5@   )   $��2q�5A   )   $��50��5B   )   ._�5C   &   � .+�5E   *   �� #��[ 5F   4   #��[ 5G   4   $��Center=�5H   4   $��Center=�5I   4   ��5E   4   �� *Name+$
 Name��y�5J   4   �� *
IsEditable+ �� 	Converter 5   /SalesManagment.BooleanToVisibiltyValueConverter  �� 5L   *   #��[ 5M   2   #��[ 5N   2   $��Center=�5O   2   $��Center=�5P   2   $��Bottom=�5Q   2   $��Center=�5R   2     TextBoxPlaceHolder#��[ 5S   2   $	��250��5T   2   $��0 4 0 0q�5U   2   ��5L   2   �� *
EditedName+$
 Name��y�5V   2   �� *
IsEditable+    �� ConverterParameter$ 	Collapsed��$ 	Collapsed��5X   '   5Z   #   �� 5]   "   $��2��6)   #��[ 5^   )   $��2q�5_   )   $��50��5`   )   ._�5b   &   �� $��2��61    �� Orientation$ 
Horizontal=�6A   .+�5d   *   �� $
��Edit��61   $��10q�5e   1   $	��150��5f   1     RegularButton#��[ 5g   1   #��[ 5h   1   ��5i   1   �� *EditCommand+�� 5j   *   $��Cancel��61   $��10q�5k   1   $	��150��5l   1   #��[ 5m   1   #��[ 5n   1   {�5o   1   �� *
IsEditable+$ False����5p   1   �� *CancelCommand+�� 5q   *   $��Delete��61   $��10q�5r   1   $	��150��5s   1   #��[ 5t   1   #��[ 5u   1   ��5v   1   �� *DeleteCommand+5x   '   5z   #   5|       �� Triggers 5      P� 5�   "    P� Property �@J�IsMouseOver P� Value . . �5�   &   ��   DarkSkyToLightSky# [ 6C    � ��5�   #   P� 5�   "    � �� . . �5�   &   ��  �@J�Opacity$	 0.9Q�6@   5�   #   P� 5�   "    �@J�	IsFocused . . �5�   &   �� # [ 6C    � ��5�   #   5�      5�      5�      5�      5�      