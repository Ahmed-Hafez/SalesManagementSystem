   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   RoundedScrollViewer �� 
TargetType �Name � ColumnDefinitions � RowDefinitions ��Name �� CanContentScroll �� CanHorizontallyScroll	 �� CanVerticallyScroll
 ��Name4   .System.Windows.Automation.AutomationProperties    AutomationId � Cursor �� ScrollableHeight � Maximum � Minimum* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize  RoundedScrollBar � Value �� Mode �� RelativeSource �� ScrollableWidth �� Orientation, �� %ComputedHorizontalScrollBarVisibility �� ViewportWidth  ScrollBarButton �� 
TargetType �� Property �� Value ��Name �� CornerRadius J� SnapsToDevicePixels  �� EndPoint! �� 
StartPoint  LightBlueColor" � Color  SkyColor# � Offset$ ��Name% �� Triggers& P� Property' P� Value( �� 
TargetName  LessLightSkyBrush  PressedLightSkyBrush  	SkyToBlue  	BlueToSky 	 RepeatButtonTransparent 
 ScrollBarThumbVertical) � 	Resources  Key* �� TargetProperty+ �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame, O� KeyTime- O� Value. ��Name/ �� RadiusY0 �� RadiusX1 N� EnterActions  ScrollViewerClick2 N� ExitActions  ScrollViewerClick_Rev  ScrollBarThumbHorizontal3 ��Name  LightGrayBrush4 ��Name5 �� LineUpCommand6 J� IsMouseOver7 F�Name8 �� Stretch9 ]�Name: ]� DecreaseRepeatButton; �� PageUpCommand< ]� IncreaseRepeatButton= �� PageDownCommand> ]� Thumb? �� LineDownCommand@ ^� 
ConditionsA �� BindingB �� ElementNameC �� Value  DarktSkyBrushD �� TriggersE �� LineLeftCommandF �� PageLeftCommandG �� PageRightCommandH �� LineRightCommand�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      &localclr-namespace:SalesManagment  5        5      �� 5   
   $ Colors.xaml?�6   �� 5   
   $ 
Fonts.xaml?�6   �� 5   
   $ 
Texts.xaml?�6   %6-  &	        &	 �    7  7  7  7  7  7  7  7  7  7  &		 �    &	
 
    7  7  7  7  7  &	 =    7  7  7  7  7  &	 �    7  7  7 	 7 	 7 
 7  7  7  7  7  7 	 7 	 7  7  7  7  �� 5      " ��62   .R�5   
   � $
 Grid��6   #��z��6    5      �� 5      $��* �6#   �� 5      $
��Auto �6#    5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $! PART_ScrollContentPresenter��6%   # z��6J    .  	 .  #��z��6�   #��z��6�   $��0��6  #��z��6"  $��0��6E  �� 5       $
 PART_VerticalScrollBar��6   $ VerticalScrollBar��68   $ Arrow��6n   $��1��6}   # z 6�   $ 0Q�6�   $��0��6�   #y�z 6�   # z 6u  #���  6�   6  �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+6�  �� 5!      $
 PART_HorizontalScrollBar��6   $ HorizontalScrollBar��6:   $ Arrow��6r   $��0��6�   # z 6�   $ 0Q�6�   $ 
Horizontal=�6�   $��1��6�   #y�z 6�   # z 6�  #���  6�   64  �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+6�  5"      5#      �� 5)      " ��6$   .�5*   
   ��  � ��$ 1q�6,   �� 5+   
    � ��$ Center=�67   �� 5,   
    � ��$ Center=�65   �� 5-   
    � ��$ 1q�6$   �� 5.   
    � |� .  6&   �� 5/   
    � �� .  6&   �� 50   
    � �� 51      �� 52      " ��6"   .R�53      �� $ border��6   $ 15��6-   $��1q�6?    . ��54      �� 55      $  -0.142,0.456&�62   $! 
0.99,0.489&�6J   .��56   "   � 8"   6/   � 57   "   8"  $# 1Q�6Q   58      ��5:      �� 5;      $  
0.99,0.489&�62   $! -0.142,0.456&�6H   .��5<   "   � 8"  6/   � 5=   "   8"  $# 1Q�6Q   5>      ._�5@      �� $$ contentPresenter��6+   |�.  #��z��6W   #��z��6�   # z 6�   #��z��6�   5A      % 5B      P� 5C      & �@J�IsMouseOver' . . �5D      �� $( border��6;   8   � ��6O   �� 5E      $( border��6<   8   � ��6P   5F      P� 5G      & � ��' . . �5H      �� $( border��6;   8   � ��6O   �� 5I      $( border��6<   8   � ��6P   5J      P� 5K      & � {�' .  . �5L      �� $( contentPresenter��68    �@J�Opacity$
 0.56Q�6V   �� 5M      $( border��6;   8   � ��6O   �� 5N      $( border��6<   8 	  � ��6P   5O      5Q      5S      5T      �� 5U      " ��6,   .�5V   
   ��  �@�OverridesDefaultStyle . 62   �� 5W   
    � ��
 ���� 6'   �� 5X   
    � |� .  6&   �� 5Y   
    � �� .  6&   �� 5Z   
    � �� 5[      �� 5\      " ��6"   .R�5]      �� #��z��6    #��z��6D   #��z��6f   5^      5`      5a      �� 5f      " n�6+   .�5g   
   ��  �@�OverridesDefaultStyle . 62   �� 5h   
    � �� .  6&   �� 5i   
    � �� 5j      �� 5k      " n�6"   ) 5l      ���� 5o      ScrollViewerClick .��5p      U� $I* C(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5q   "     $, 0:0:0.3��67   $- 0.586Q�6I   5r      U� 5s      $I* C(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5t   "     $, 0:0:0.3��67   $- 1Q�6I   5u      U� 5v      $I* C(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5w   "     $, 0:0:0.3��67   $- 0.444Q�6I   5x      5y      �� 5z      ScrollViewerClick_Rev .��5{      U� $I* C(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5|   "   �� $, 0:0:0.3��67   $
- 0.43Q�6I   5}      U� 5~      $I* C(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5   "   �� $, 0:0:0.3��67   $- 0.579Q�6I   5�      U� 5�      $I* C(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5�   "   �� $, 0:0:0.3��67   $- 0Q�6I   5�      5�      5�      .R�5�      �� $. 	rectangle��6    #��z��63    . #��z��6p   $/ 7��6�   $0 7��6�   ��5�      �� 5�      $  
0.462,4.99&�62   $! 0.493,-4.068&�6H   .��5�   "   � 8"   $# 0.579Q�6Q   � 5�   "   8"  $
# 0.43Q�6X   � 5�   "   8"  $# 0Q�6Q   5�      5�      % 5�      P� 5�      & �@J�IsMouseOver' . 69   P� 5�      & �@n�
IsDragging' . 1 5�      �� 5�   "   8�� 62   2 5�      �� 5�   "   8�� 62   5�      5�      5�      5�      �� 5�      " n�6-   .�5�   
   ��  �@�OverridesDefaultStyle . 62   �� 5�   
    � �� .  6&   �� 5�   
    � �� 5�      �� 5�      " n�6"   ) 5�      ���� 5�      ScrollViewerClick .��5�      U� $I* C(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5�   "     $, 0:0:0.2��67   $- 0.976Q�6I   5�      U� 5�      $I* C(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5�   "     $, 0:0:0.2��67   $- 0.535Q�6I   5�      U� 5�      $I* C(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5�   "     $, 0:0:0.2��67   $- 0.131Q�6I   5�      5�      �� 5�      ScrollViewerClick_Rev .��5�      U� $I* C(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5�   "   �� $, 0:0:0.2��67   $- 0.657Q�6I   5�      U� 5�      $I* C(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5�   "   �� $, 0:0:0.2��67   $- 0.263Q�6I   5�      U� 5�      $I* C(Shape.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Offset)�6<   $+ 	rectangle��6�   .\�5�   "   �� $, 0:0:0.2��67   $- 0Q�6I   5�      5�      5�      .R�5�      �� $. 	rectangle��6    #��z��63    . #��z��6p   $/ 7��6�   $0 7��6�   ��5�      �� 5�      $  
-0.892,0.5&�62   $! 1.466,0.499&�6H   .��5�   "   � 8"   $# 0.657Q�6Q   � 5�   "   8"  $# 0.263Q�6X   � 5�   "   8"  $# 0Q�6Q   5�      5�      % 5�      P� 5�      & �@J�IsMouseOver' . 69   P� 5�      & �@n�
IsDragging' . 1 5�      �� 5�   "   8�� 62   2 5�      �� 5�   "   $+3 %ScrollViewerClick_Rev_BeginStoryboard��62   8�� 6a   5�      5�      5�      5�      �� 5�      " ��6%   .�5�   
   ��  �@��IsPressAndHoldEnabled .  69   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � ��$	 1,0q�6,   �� 5�   
    � ��# � r�6"   �� 5�   
    � ��# � r�6%   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � $ Bg��6    .  5�      �� 5�      #��� q�6,   �� 5�      $��0.00001* �6,   �� 5�      #��� q�6,   .+�5�      �� $��0q�6!   $ 7��65   8��  $��1��6s   �� 5�      $4 PART_LineUpButton��6'   #��Z5 6B   #{�z6 6o   8�� .��5�      F� $7 ArrowTop��6#   �����     	= �     	= ��[ ��[ �    ��[ �g5 �%& �g5 �%& ��g5 �%& ��j ��[ ��j ��[ ���j ��[ ��j  	= ��j  	= ���j  	= �g5  � �g5  � ��g5  �  	=  	= 	
�������$��3,4,3,3q�6�   $8 Uniform=�6�   5�      ]� 5�      $9 
PART_Track��6    ��. #{�z6 6O   $��1��6y   : 5�      �� 5�   "   #��Z; 6/   8�� 6\   < 5�      �� 5�   "   #��Z= 6/   8�� 6^   > 5�      n� 5�   "   8�� 6(   5�      �� 5�      $4 PART_LineDownButton��6'   #��Z? 6D   #{�z6 6s   $��2��6�   8�� .��5�      F� $7 ArrowBottom��6#   �����    �%& �    �%&  �  � �     � �g5  	= �g5  	= ��g5  	= ��j  � ��j  � ���j  � ��j �%& ��j �%& ���j �%& �g5 ��[ �g5 ��[ ��g5 ��[ �%& �%& 	
�������$��3,4,3,3q�6�   $8 Uniform=�6�   5�      5�      % 5�      ^� 5�      @ 5�      �� 5   "   A 6,   �� *IsMouseOver+$B PART_LineDownButton��C true6m   �� 5  "   A 6,   �� *	IsPressed+$B PART_LineDownButton��C true6k   .0�5     �� $( ArrowBottom��65   8   � ��6N   5     ^� 5     @ 5     �� 5  "   A 6,   �� *IsMouseOver+$B PART_LineUpButton��C true6k   �� 5  "   A 6,   �� *	IsPressed+$B PART_LineUpButton��C true6i   .0�5
     �� $( ArrowTop��65   8   � ��6K   5     ^� 5     @ 5     �� 5  "   A 6,   �� *IsMouseOver+$B PART_LineDownButton��C true6m   �� 5  "   A 6,   �� *	IsPressed+$B PART_LineDownButton��	C false6k   .0�5     �� $( ArrowBottom��65    � ��
 �����6N   5     ^� 5     @ 5     �� 5  "   A 6,   �� *IsMouseOver+$B PART_LineUpButton��C true6k   �� 5  "   A 6,   �� *	IsPressed+$B PART_LineUpButton��	C false6i   .0�5     �� $( ArrowTop��65    � ��
 �����6K   5     P� 5     & � {�' .  67   5     5     D 5  
   P� 5      & �@��Orientation$' 
Horizontal=�6-   . �5!     ��  � ��$
 Auto��6*   �� 5"      � ��$ 0��6-   �� 5#      � ��# � ��6+   �� 5$      � ��# � ��6.   �� 5%      � ��$	 0,1q�64   �� 5&      � �� 5'     �� 5(     " ��6*   .R�5)     � $ Bg��6#    .  5*  "   �� 5+  &   #��� ��67   �� 5,  &   $��0.00001* �67   �� 5-  &   #��� ��67   .+�5/  "   �� $��0q�6)   $ 7��6=   8�� $��1��6{   �� 50  "   $4 PART_LineLeftButton��6/   #��ZE 6L   #{�z6 6{   8��	 .��51  &   F� $7 	ArrowLeft��6+   �������0 ��j ���0 ��j @KL ��j @KL ��j �@KL ��j P� �g5 P� �g5 �P� �g5 @KL @KL �@KL     ��0 ��0 ���0     �g5 �g5 �    �g5 ��0 ��j ��0 ��j 	
�������$��3q�6�   $8 Uniform=�6�   52  #   ]� 53  "   $9 
PART_Track��6(   $��1��6<   #{�z6 6L   : 54  &   �� 55  *   #��ZF 67   8��
 6f   < 57  &   �� 58  *   #��ZG 67   8�� 6g   > 5:  &   n� 5;  *   8�� 60   5=  #   �� 5>  "   $4 PART_LineRightButton��6/   $��2��6M   #��ZH 6]   #{�z6 6�   8�� .��5?  &   F� $7 
ArrowRight��6+   �����P� ��j �P� ��j ��j ��j �    ��j ��0 �g5 ��0 �g5 ���0 �g5 �        P� P� �P�     @KL �g5 @KL �g5 �@KL �g5 P� ��j P� ��j 	
�������$��3q�6�   $8 Uniform=�6�   5@  #   5A     % 5B     ^� 5C  "   @ 5D  &   �� 5E  *   A 64   �� *IsMouseOver+$B PART_LineRightButton��C true6v   �� 5F  *   A 64   �� *	IsPressed+$B PART_LineRightButton��C true6t   .0�5H  &   �� $( 
ArrowRight��6=   8   � ��6U   5I  #   ^� 5J  "   @ 5K  &   �� 5L  *   A 64   �� *IsMouseOver+$B PART_LineLeftButton��C true6u   �� 5M  *   A 64   �� *	IsPressed+$B PART_LineLeftButton��C true6s   .0�5O  &   �� $( 	ArrowLeft��6=   8   � ��6T   5P  #   ^� 5Q  "   @ 5R  &   �� 5S  *   A 64   �� *IsMouseOver+$B PART_LineRightButton��C true6v   �� 5T  *   A 64   �� *	IsPressed+$B PART_LineRightButton��	C false6t   .0�5V  &   �� $( 
ArrowRight��6=    � ��
 �����6U   5W  #   ^� 5X  "   @ 5Y  &   �� 5Z  *   A 64   �� *IsMouseOver+$B PART_LineLeftButton��C true6u   �� 5[  *   A 64   �� *	IsPressed+$B PART_LineLeftButton��	C false6s   .0�5]  &   �� $( 	ArrowLeft��6=    � ��
 �����6T   5^  #   P� 5_  "   & � {�' .  6?   5a     5c     5d     5f     5i     