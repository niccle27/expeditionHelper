   M S B A M L   `   `   `  ����K  GExpeditionHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ExpeditionHelperExpeditionHelper  5   	   #    ExpeditionHelper.WindowVoyage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ExpeditionHelper     5   	     � Title$  WindowVoyage��5   	   $��1��6   $��1��6,   $	��190��69   $	��300��6F   .��5	      ��  �� Padding$ 20q�6   ._�5
   
   �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Name:��6   $��DemiBold"�6-   �� 5   
   -   5        $��tb_nom��5   0   $��0��6   $��1��6   ��6>   �� *Nom+ �� Mode$ TwoWay=��� 5   
   $��1��6   $��From:��6   $��DemiBold"�6-   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��calendar_debut��5   3   $��1��6   $��1��6"      SelectedDate 6I   �� *Debut+$ TwoWay=��� 5   
   $��2��6   $	��To:��6   $��DemiBold"�6+     5   
   -   5        $��calendar_fin��5   3   $��2��6   $��1��6"    6G   �� *Fin+$ TwoWay=��� 5   
   -   5        $��btn_ok��5   s   $��3��6   $��2��6   $��10q�62   $��OK��6>   $��40��6K   $��Center=�6V   6�   5      5      5!      