   M S B A M L   `   `   `  ����I  ESalesManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalesManagmentSalesManagment  5      (    "SalesManagment.ClientRowViewerList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SalesManagment     5        � DataContext  5
      1   +SalesManagment.ClientRowViewerListViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6      DarkToLightToDarkSky#��[  5      $��3q�5      $��10q�5       �� CornerRadius$ 5��5      ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5       $
��auto �6'   �� 5!      $��* �6'   .+�5$      �� $��1��6    �� Orientation$ 
Horizontal=�5%      .+�5'      �� $��
Search By:��6    $��28(�5(      $��Center=�5)        ForegroundLightBrush#��[ 5*      $��0 0 40 0q�5+      �� 5-      $	��200��6   $��Center=�5.      $��28(�5/      #��[ 50        HollowComboBox#��[ 51      $��0 0 40 0q�54      ��52      ��   ClientSearchEnumMenu �� Source# [  �� SelectedItem 53      �� *ClientSearchType+54      �� 56        TextBoxPlaceHolder#��[ 6   $��Center=�57      $��Center=�58      $��28(�59      $	��500��5<      $	��500��5=        ForegroundMainBrush �� 
CaretBrush# [ 5>        LightRedSelectionBrush �� SelectionBrush# [ 5?      
	 � Tag	 5:      �� *	SearchTag+��5;      �� *
SearchText+
 �� UpdateSourceTrigger$
 PropertyChanged=�5?      5A      5C      5E      �� 5G   
   $��2��6   |�.  ��5H      �� *Items+$
 PropertyChanged=���5J      �� 5K      .R�5L      $   SalesManagment.ClientRowViewer  5M      5O      5Q      5R      