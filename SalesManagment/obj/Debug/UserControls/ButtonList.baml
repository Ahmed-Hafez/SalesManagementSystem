   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5          SalesManagment.ButtonList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SalesManagment     5      -   5          >�Name$  ButtonListUS��5      $
��auto��5	       � Triggers 5      :� 5   
    :� RoutedEvent$ local:ButtonList.Open��6   .[�5      �� .��5      �� .��5      W�  �� 
TargetName$ ArrowUp��6&    �� TargetProperty$9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5   &    W� From$ 0X�5   &   	 W� To$	 180X�5   &    g� Duration$ 0:0:0.3D�5   &    g� AccelerationRatio$	 0.8Q�5   &   W� 5      $ Height�6&   $ 53X�5   &   $ 0:0:0.3D�5   &    5   &   �� *AnimatedHeight+	 �� ElementName$	 ButtonListUS��5   &   5       5!      5"      :� 5%   
   $ local:ButtonList.Close��6   .[�5&      �� .��5'      �� .��5*      W� $ ArrowUp��6&   $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5+   &   $	 180X�5,   &   $	 360X�5-   &   $ 0:0:0.3D�5.   &   $	 0.8Q�5/   &   W� 52      $ Height�6&   $ 53X�54   &   $ 0:0:0.3D�55   &    53   &   �� *AnimatedHeight+$	 ButtonListUS��55   &   56      57      58      .��5<      � 
 � RowDefinitions
 5=   
   �� 5@      $
��auto �6   �� 5C      $
��auto �6   .+�5H   
   � $��0��6   
 5I      �� 5J      $
��auto �6    �� 5K      $
��auto �6    .+�5N      �� -   5         ��Name$ 
MainButton��5N      
���  �� 5Q      :� 5R      $ 
MouseEnter��6#   .[�5S      �� .��5T      �� $	 0.8Q�6)   .��5U   "   �� $ Background.Color�61    �� From$	 RedX�6^   	 �� To$ GreenX�6i   $ 0:0:0.3D�6t   5V      5W      5X      :� 5Y      $ 
MouseLeave��6#   .[�5Z      �� .��5[      �� $	 0.8Q�6)   .��5\   "   �� $ Background.Color�61   $ GreenX�6^   $	 RedX�6k   $ 0:0:0.3D�6t   5]      5^      5_      :� 5`      $ 	MouseDown��6#   .[�5a      �� .��5b      �� .��5d   "   �� $ Background.Color�61   $
 BlueX�5e   1   $ GreenX�5f   1   $ 0:0:0.1D�5g   1   5j      5k      5l      :� 5m      $ MouseUp��6#   .[�5n      �� .��5o      �� .��5p   "   �� $ Background.Color�61   $ GreenX�5q   1   $
 BlueX�5r   1   $ 0:0:0.1D�5s   1   5t      5u      5v      ._�5{      � 
 5|      �� 5      $
��auto �6(   �� 5�      $
��auto �6(   .+�5�      �� 
�������$��32(�5�       $��Center=�5�       ��5�       �� *Title+$	 ButtonListUS�� �� FallbackValue$ Ahmed��5�       �� 5�      $��1��6   ��5�      �� $	 
MainButton�� �� Path$ 
Background�._�5�      F� -   5         F�Name$ ArrowUp��5�      $��2��5�      
�������$��Center=�5�      +����        р�� ��� � -1    �        	 J� RenderTransformOrigin$ 0.5,0.5&�5�      z�5�      �� 5�   "    �� Angle$ 0Q�62   5�      5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ ButtonListContent��5�      
�������$��1��5�      5�      5�      