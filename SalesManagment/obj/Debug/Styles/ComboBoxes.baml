   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 6@   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   ComboBoxToggleButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels F�Name	 �� Triggers
 ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value P� Property P� Value �� 
TargetName  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5   /Microsoft.Windows.Themes.SystemDropShadowChrome   Name    Color �� MaxDropDownHeight �� ElementName  DarkSkyMask  VeryLightSkyMask ��Name �� ClearTypeHint ��Name ��Name ��Name-  'System.Windows.Input.KeyboardNavigation    DirectionalNavigation! d�Name" d� 	IsChecked# ��Name$ �� SelectionBoxItemTemplate% �� SelectionBoxItem#& �� SelectionBoxItemStringFormat' �� ContentStringFormat( J� IsHitTestVisible) P� 
SourceName* ]� 
Conditions+ �� Property  ComboBoxEditableTextBox  ComboBoxEditableTemplate, ��Name- �� 
IsReadOnly  HollowComboBox. �� Triggers�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      &localclr-namespace:SalesManagment  5      VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  6@     5      �� 5   
   $ Colors.xaml?�6   %u  &	        &	 �    7  7  7   &	 �    &	     7   7  &	 �    7  7  �� 5
      " d�6)   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5   
    � |� .  6&   �� 5   
    �@��	ClickMode$ Press=�6&   �� 5   
    � �� 5      �� 5      " d�6"   .R�5      �� $ templateRoot��6    . 
������ $��0 0 0 3q�6g   #��z��6�   ._�5      �� $ splitBorder��6!   #��� r�66    . $��0q�6�   $��Right=�6�   $��1q�6�   
������ ._�5      F� $ arrow��6#   $��Center=�62   $��0q�6M   $��Center=�6X   #��z��6u   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        6�   5      5      	 5      ^� 5      
 5      �� 5   "    6,   �� *
IsEditable+ �� " �� true6�   �� 5   "    6,   �� *IsMouseOver+ �� *Self+	 false6r   �� 5   "    6,   �� *	IsPressed+ �� *Self+	 false6p   �� 5   "    6,   �� *	IsEnabled+ �� *Self+ true6p   5      P� 5        �@J�IsMouseOver . . �5!      �� $ arrow��65    � ��
 �����6H   5"      ^� 5#      
 5$      �� 5%   "    6,   �� *IsMouseOver+ �� *Self+ true6r   �� 5&   "    6,   �� *
IsEditable+ �� " ��	 false6�   .0�5(      �� $ templateRoot��6;    � ��
 ���� 6U   �� 5)      $ templateRoot��6<    � ��
 �����6V   5*      ^� 5+      
 5,      �� 5-   "    6,   �� *IsMouseOver+ �� *Self+ true6r   �� 5.   "    6,   �� *
IsEditable+ �� " �� true6�   50      P� 51       � �� . 67   ^� 52      
 53      �� 54   "    6,   �� *	IsPressed+ �� *Self+ true6p   �� 55   "    6,   �� *
IsEditable+ �� " ��	 false6�   .0�57      �� $ templateRoot��6;    � ��
 ���� 6U   �� 58      $ templateRoot��6<    � ��
 ���� 6V   59      ^� 5:      
 5;      �� 5<   "    6,   �� *	IsPressed+ �� *Self+ true6p   �� 5=   "    6,   �� *
IsEditable+ �� " �� true6�   5?      P� 5@       � {� .  67   5B      5D      5E      �� 5F      " ��6/   .R�5G   
   � $ templateRoot��6    .  5H      �� 5I      $��* �6#   �� 5J      #��� r�6#   $��0 �6v   .+�5L      � $ 
PART_Popup��6    . $��2��6B   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6V   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5M         $ shadow��60   $ Transparent��6@   #��z 6T   ��6�   �� *ActualWidth+$ templateRoot��._�5N      �� $ dropDownBorder��6   8��  $��1q�6`   8�� ._�5O      �� $ DropDownScrollViewer��6'   .��5P      � $
 grid��6#   $ Enabled=�61   .+�5Q   "   �� $ canvas��6)   $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5R   &   �� $ 
opaqueRect��60   ��6D   �� *
Background+$ dropDownBorder����6|   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5S   #   �� 5T   "   $ ItemsPresenter��61   $  	Contained=�6I   # z 6~   5U      5V      5W      5X      5Y      d� 5Z      $! toggleButton��6   #��z��61   #��z��6]   #��z��6�   $��2��6�   8�� " 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+62  �� 5[      $# contentPresenter��6   #��z$ 69   #��z��6v   #��z% 6�   #' z& 6�   #��z��6)  ( .  #��z��6�  # z 6�  #��z��6�  5\      	 5]   
   P� 5^      $) 
PART_Popup��6/    �@�HasDropShadow . . �5_      �� $ shadow��6+    � ��$ 0,0,5,5q�6?   �� 5`      $ shadow��6*    �@  Color$ 	#71000000��6>   5a      P� 5b       �@��HasItems .  . �5c      �� $ dropDownBorder��6+    � ��$ 95��6G   5d      ]� 5e      * 5f      �� 5g      + �@��
IsGrouping . 66   �� 5h      "+ �@%�IsVirtualizingWhenGrouping .  6X   ./�5j      ��  � �� .  6B   5k      P� 5l      $) DropDownScrollViewer��6?    � �� .  . �5m      �� $ 
opaqueRect��6/    6G   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5n      $ 
opaqueRect��60    6H   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5o      5q      �� 5r      " ��6,   .�5s   
   ��  �@�OverridesDefaultStyle . 62   �� 5t   
    �@J�	AllowDrop . 6&   �� 5u   
    � ��$ 0��6%   �� 5v   
    � ��$ 0��6&   �� 5w   
    �@�FocusVisualStyle 6-   Z� �� 5x   
    �@��PanningMode$ VerticalFirst=�65   �� 5y   
    �@��IsFlicksEnabled .  63   �� 5z   
    � �� 5{      �� 5|      " ��6"   .R�5}      �� $ PART_ContentHost��6#   
������ |�.  $��Hidden=�6h   $��Hidden=�6�   5~      5�      5�      �� 5�      " ��67   .R�5�   
   � $ templateRoot��6    .  5�      �� 5�      $��* �6#   �� 5�      #��� r�6#   $��0 �6v   .+�5�      � $ 
PART_Popup��6    . $��2��6B   #��� .�6�   $��Bottom=�6  ��6V   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�         $ shadow��60   $ Transparent��6@   #��z 6T   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $ dropDownBorder��6   #��� ��65   $��1q�6�   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6'   .��5�      � $
 grid��6#   $ Enabled=�61   .+�5�   "   �� $ canvas��6)   $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5�   &   �� $ 
opaqueRect��60   ��6D   �� *
Background+$ dropDownBorder����6|   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   #   �� 5�   "   $ ItemsPresenter��61   $  	Contained=�6I   # z 6~   5�      5�      5�      5�      5�      d� 5�      $! toggleButton��6   #��z��61   #��z��6]   #��z��6�   $��2��6�   8��  " 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+62  �� 5�      $ border��6   #��z��6%   ._�5�      �� $, PART_EditableTextBox��6   #��z��68   #��z��6�   8�� #��z��6)  - 6�   �� *
IsReadOnly+ �� *TemplatedParent+6)  5�      5�      	 5�   
   P� 5�       � {� .  . �5�      �� $ border��6,    �@J�Opacity$
 0.56Q�6@   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
 �   �6/   5�      P� 5�      $) 
PART_Popup��6/    �@�HasDropShadow . . �5�      �� $ shadow��6+    � ��$ 0,0,5,5q�6?   �� 5�      $ shadow��6*    �@  Color$ 	#71000000��6>   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6+    � ��$ 95��6G   5�      ]� 5�      * 5�      �� 5�      + �@��
IsGrouping . 66   �� 5�      "+ �@%�IsVirtualizingWhenGrouping .  6X   ./�5�      ��  � �� .  6B   5�      P� 5�      $) DropDownScrollViewer��6?    � �� .  . �5�      �� $ 
opaqueRect��6/    6G   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��60    6H   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�      5�      �� 5�      " ��6#   .�5�   
   ��  � |� .  6&   �� 5�   
    � ��# � ��6'   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � ��$
 Auto=�6G   �� 5�   
    � ��$
 Auto=�6E   �� 5�   
    � ��$ 6,3,5,3q�6$   �� 5�   
    � �� . 6:   �� 5�   
    �@��PanningMode$
 Both=�65   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � ��8   6%   . 5�   
   P� 5�       �@��
IsEditable . . �5�      ��  � �� .  6.   �� 5�       � ��$ 2q�6,   �� 5�       � ��8  6-   5�      P� 5�       � {� .  . �5�      ��  �@J�Opacity$	 0.3Q�6,   5�      5�      5�      