   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5      %    SalesManagment.AddingClientPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SalesManagment     5      -   5           SalesManagment.BasePage`1   Name$  AddingClientView��5       N� Title$ Add New Client��5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $��0��6   $��0��5      $��2��5         FontSizeMedium#��[  5        LatoRegular#��[ 5        ForegroundLightBrush#��[ 5      $��Center=�5      $��Center=�5      $	��Top=�5      $��60��5      $	��500��5        RoundedTextBox#��[ 5      $
��10,5q�5       {�.    DarktSkyBrush#��[ 5!   $   ��5      ��  �� ElementName$ AddingClientView�� �� Path$ Title� �� FallbackValue$ Add New Client����5      �� *PageTitleMargin+$ 0 30 0 0�� � ContextMenu 5"      Z� �� 5$   
   $��1��6   $��Center=�5%      $��Center=�5&      
������ $��3q�5*      
���������5'      �� *BorderFrameMargin+$ 0 0 0 80�� �� Padding 5(      �� *BorderFramePadding+$ 20 50 20 15��._�5-      � $��1��6   $��Center=�5.      $��Center=�5/      $��-3q�50       52      �� 53      $��40 �6$   �� 54      $��40 �6$   �� 55      $��40 �6$   �� 56      $��40 �6$   �� 57      $	��100 �6$   �� 58      $��40 �6$   �� 59      $��40 �6$   �� 5:      $��40 �6$    � ColumnDefinitions 5=      �� 5>      $	��170 �6'   �� 5?      $	��350 �6'   �� 5@      $	��400 �6'   �� 5A      .+�5E      �� $��0��6   $��0��5F      $��
First Name��5G      #��[ 5H        FontSizeRegular#��[ 5I      #��[ 5J      $	��Top=�5L      $
��Left=�5M      ��5K      �� *LeftContentPadding+$ 0 5 0 0��5M      �� 5N      $��0��6   $��1��5O      $	��Top=�5P      $
��Left=�5Q        TextBoxPlaceHolder#��[ 5R      $��0q�5S      
������ 
	 � Tag$	 
First Name��5U      #��[ 5W      #��[ 5X      #��[ 5Y        LightRedSelectionBrush
 �� SelectionBrush#
 [ 5Z      $	��200��5\      $��1��5]      ��5V      �� *ClientFirstName+ �� 
CaretBrush 5[      ��  �� RelativeSource ��  �� Mode$
 Self=�$ 
Foreground�5]      �� 5`      $��1��6   $��0��5a      $��Second Name��5b      #��[ 5c      #��[ 5d      #��[ 5e      $	��Top=�5g      $
��Left=�5h      ��5f      �� *LeftContentPadding+$ 0 5 0 0��5h      �� 5i      $��1��6   $��1��5j      $	��Top=�5k      $
��Left=�5l      #��[ 5m      $��0q�5n      
������ $	 Second Name��5p      #��[ 5r      #��[ 5s      #��[ 5t      #
 [ 5u      $	��200��5w      $��2��5x      ��5q      �� *ClientSecondName+ 5v      ��  �� $
 Self=�$ 
Foreground�5x      �� 5{      $��2��6   $��0��5|      $��Gender��5}      #��[ 5~      #��[ 5      #��[ 5�      $	��Top=�5�      $
��Left=�5�      ��5�      �� *LeftContentPadding+$ 0 5 0 0��5�      �� 5�      $��2��6   $��1��5�      $	��Top=�5�      $
��Left=�5�        HollowComboBox#��[ 5�      $��0q�5�      #��[ 5�      #��[ 5�      #��[ 5�      #��[ 5�      $	��200��5�      $��2��5�      ��5�      ��  	 GenderEnumMenu �� Source# [	  �� SelectedItem 5�      �� *ClientGender+5�      �� 5�      $��3��6   $��0��5�      $��Phone��5�      #��[ 5�      #��[ 5�      #��[ 5�      $	��Top=�5�      $
��Left=�5�      ��5�      �� *LeftContentPadding+$ 0 5 0 0��5�      !   SalesManagment.PhoneTextBox  5�      $��3��6%   $��1��5�   &   $	��Top=�5�   &   $
��Left=�5�   &   #��[ 5�   &   $��0q�5�   &   
������ $	 Phone��5�   &   #��[ 5�   &   #��[ 5�   &   #��[ 5�   &   #
 [ 5�   &   $	��200��5�   &   $��3��5�   &   ��5�   &   �� *ClientPhone+ 5�   &   ��  �� $
 Self=�$ 
Foreground�5�   &   �� 5�      $��4��6   $��0��5�      $��Email��5�      #��[ 5�      #��[ 5�      #��[ 5�      $	��Top=�5�      $
��Left=�5�      ��5�      �� *LeftContentPadding+$ 0 5 0 0��5�      �� 5�      $��4��6   $��1��5�      $	��Top=�5�      $
��Left=�5�      #��[ 5�      $��0q�5�      
������ $	 Email��5�      #��[ 5�      #��[ 5�      #��[ 5�      #
 [ 5�      $	��200��5�      $��4��5�      ��5�      �� *ClientEmail+ 5�      ��  �� $
 Self=�$ 
Foreground�5�      �� 5�      $��1��6   $��6��5�      $��2��5�      $��
50 -20 0 0q�5�      $	��Top=�5�      #��[ 5�       
 LightWhiteBrush#��[
 5�      ��5�      �� *ProductImageFrameWidth+$	 200����5�      �� *ProductImageFrameHeight+$	 250����5�      �� *ProductImageFrameThickness+$ 2��._�5�      �� $
��Fill=�5�       ��5�      �� *ClientImagePath+5�       5�      �� 5�      $��5��6   $��2��5�      $��2��5�      $��Center=�5�      $��25 0 0 0q�5�      $	��250��5�      $��Select Photo��5�        RoundedButton#��[ 5�      #��[ 5�      $��5��5�      ��5�      �� *SelectPhotoCommand+5�      �� 5�      $��7��6   $��2��5�      $��
200 10 0 0q�5�      $	��200��5�      $	��Add��5�        RegularButton#��[ 5�      #��[ 5�      $��6��5�      ��5�      �� *AddClientCommand+5�      5�      5�      5�      5�      