   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5          SalesManagment.CartPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SalesManagment     5      -   5           SalesManagment.BasePage`1   Name$
  Cart��5      $	��900��5	       N� Title$
 Cart��5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $��0��6   $��0��5      $��2��5         FontSizeMedium#��[  5        LatoRegular#��[ 5        ForegroundLightBrush#��[ 5      $��Center=�5      $��Center=�5      $	��Top=�5      $��60��5      $	��500��5        RoundedTextBox#��[ 5       $
��10,5q�5!      {�.    DarktSkyBrush#��[ 5"   $   ��5      ��  �� ElementName$
 Cart�� �� Path$ Title� �� FallbackValue$
 Cart����5      �� *PageTitleMargin+$ 0 30 0 0�� � ContextMenu 5#      Z� �� 5%   
   -   5         ��Name$ 
MainBorder��5%      $��1��5&      $��Center=�5'      
������ $��3q�5+        BackgroundVeryLightBrush#��[ 5,      ��5(      �� *MinFrameWidth+��5)      �� *MinFrameHeight+$	 800����5-      �� *BorderFrameMargin+$ 0 0 0 20�� �� Padding 5.      �� *BorderFramePadding+$ 0��._�50      �  51      �� 54      $��* �6$   �� 57      $
��auto �6$   	 � ColumnDefinitions	 5:      �� 5<      �� 5=      .+�5B      '   !SalesManagment.OrderRowViewerList  -   5        
  Name$
 
OrdersList��5B   +   $��0��5C   +   $��0��5D   +   $��2��5E   +   $��
10 10 10 0q�5F   +   5H      5K      5L      5M      