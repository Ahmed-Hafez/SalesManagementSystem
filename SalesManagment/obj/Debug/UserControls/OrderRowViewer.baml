   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5      #    SalesManagment.OrderRowViewer   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SalesManagment     5      .��5
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
MainBorder��6#   #��z��67    � ColumnDefinitions 5&   "   �� 5'   &   $��40 �67   �� 5(   &   $��2* �67   �� 5)   &   �� 5*   &   �� 5+   &   �� 5,   &   �� 5-   &   $	��100 �67   .+�51   "   �� $��0��6)     BackgroundVeryLightBrush#��[ 52   )   $��0 2 2 2q�53   )   $��50��54   )   ._�56   *   ��   ForegroundLightBrush#��[ 57   4     FontSizeSmall#��[ 58   4   $��Center=�59   4   $��Center=�5:   4   ��56   4   �� *	RowNumber+ �� FallbackValue$ i��5:   4   5<   #   �� 5?   "   $��1��6)   #��[ 5@   )   $��2q�5A   )   $��50��5B   )   ._�5D   &   �� #��[ 5E   4   #��[ 5F   4   $��Center=�5G   4   $��Center=�5H   4   ��5D   0   �� *ProductName+$ ProductName��y�5I   4   �� *
IsEditable+ �� 	Converter 5   /SalesManagment.BooleanToVisibiltyValueConverter  5K   #   �� 5N   "   $��2��6)   #��[ 5O   )   $��2q�5P   )   $��50��5Q   )   ._�5S   &   �� #��[ 5T   4   #��[ 5U   4   $��Center=�5V   4   $��Center=�5W   4   ��5S   0   �� *ProductPrice+$ Product Price��y�5X   4   �� *
IsEditable+   5Z   #   �� 5]   "   $��3��6)   #��[ 5^   )   $��2q�5_   )   $��50��5`   )   ._�5b   &   #   SalesManagment.NumericTextBox  $��Center=�6;   $��Center=�5c   ;     TextBoxPlaceHolder#��[ 5d   ;   $��0q�5e   ;   
������ 
 � Tag$ 1��5g   ;     LatoRegular#��[ 5i   ;     FontSizeRegular#��[ 5j   ;   #��[ 5k   ;    	 LightRedSelectionBrush �� SelectionBrush# [	 5l   ;   $��75��5n   ;   $��80��5o   ;    �� TextAlignment$ Center=�5p   ;      HasDecimalPoint .  ��5h   ;   �� *QuantityString+$ 1�� �� UpdateSourceTrigger$ PropertyChanged=� �� 
CaretBrush 5m   ;   ��  �� RelativeSource ��  �� Mode$
 Self=� �� Path$ 
Foreground�{�5r   ;   �� *	CanDelete+5s   #   �� 5v   "   $��4��6)   #��[ 5w   )   $��2q�5x   )   $��50��5y   )   ._�5{   &     $��Center=�6;   $��Center=�5|   ;   #��[ 5}   ;   $��0q�5~   ;   
������ $	 0.0��5�   ;   #��[ 5�   ;   #��[ 5�   ;   #��[ 5�   ;   # [	 5�   ;   $��75��5�   ;   $��80��5�   ;   $ Center=�5�   ;    . ��5�   ;   �� *DiscountString+$	 0.0��$ PropertyChanged=� 5�   ;   ��  �� $
 Self=�$ 
Foreground�{�5�   ;   �� *	CanDelete+5�   #   �� 5�   "   $��5��6)   #��[ 5�   )   $��2q�5�   )   $��50��5�   )   ._�5�   &   �� #��[ 5�   4   #��[ 5�   4   $��Center=�5�   4   $��Center=�5�   4   ��5�   0   �� *
TotalPrice+$ Total Price��y�5�   4   �� *
IsEditable+   5�   #   �� 5�   "   $��10��6)   #��[ 5�   )   $��2q�5�   )   $��50��5�   )   ._�5�   &   �� $��Delete��6-   $��10q�5�   -   $��60��5�   -    
 RegularButton#��[
 5�   -   #��[ 5�   -   ��5�   -   �� *DeleteCommand+{�5�   -   �� *	CanDelete+5�   #   5�       �� Triggers 5�      P� 5�   "    P� Property �@J�IsMouseOver P� Value . . �5�   &   ��   DarkSkyToLightSky# [ 6C    � ��5�   #   P� 5�   "    � �� . . �5�   &   ��  �@J�Opacity$	 0.9Q�6@   5�   #   P� 5�   "    �@J�	IsFocused . . �5�   &   �� # [ 6C    � ��5�   #   5�      5�      5�      5�      5�      