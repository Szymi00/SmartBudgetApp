   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   N JTowam - projekt (1), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Towam___projekt__1_Towam___projekt__1_ 5   	   !   Towam___projekt__1_.Window2   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   3local!clr-namespace:Towam___projekt__1_     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Window2��5
   	   $	��650��6   $	��850��6&   ���	#FF0A41FF.��5      � $��0,0,3.6,1.4q�6   ���	#FF4778FF � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
      LiveCharts.Wpf.PieChart  -   5          Name$ pieChart��5      $��1��6*   $��1��67   $
��Auto��6G   $
��Auto��6T   $��Stretch=�5      $��Stretch=�5      &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�5         Series 5      �� *PieChartData+ � DataContext 5      ��  �� RelativeSource ��  �� AncestorType" �	 �� Mode$	 FindAncestor=��� 5   
   -   5        
 ��Name$
 Load_Btn��5      $
��Load��6#   $
��Left=�62   $��39��6M   $��260,360,0,0q�6Y   $	��Top=�6n   $	��120��6�   6�   �� 5    
   -   5        $
 back_Btn��5!      $��2��5       $��0��6   $
��Back��5"      $��Center=�5$      $��Bottom=�5%      $��10,0,10,-0.2q�6(   $	��128��6>   �� 5'   
   -   5        $
 Load_btn��5(      $��2��5'      $��2��6   $
��Load��5)      $��Center=�5+      $��Bottom=�5,      $��9.8,0,10.4,-0.2q�6(   $	��127��6A   5.      5/      