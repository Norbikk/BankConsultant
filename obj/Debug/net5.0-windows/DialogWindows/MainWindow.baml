   M S B A M L   `   `   `  ����I  EBankConsultant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BankConsultantBankConsultant  5   	       BankConsultant.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BankConsultant     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��500��5	   	   $	��850��5
   	   
����ح�.��5      �  � RowDefinitions 5   
   �� 5   
   $��30 �6   �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6#   �� 5      $��* �6   .+�5   
   �� -   5        $��BtnPageUser��5      $'��!Поле пользователя��5      $��14(�5      
����ح�5      �� 5   
   -   5        $��BtnPageConsult��5      $��1��6)   $'��!Поле консультанта��5       $��14(�5!      
����ح�5#      �� 5$   
   -   5        $��BtnPageManager��5$      $��2��6)   $!��Поле Менеджера��5%      $��14(�5&      
����ح�5(       � 5)      -   5        $��	MainFrame��5)      $��0��6   $��4��6*   $��3��6;   $��Stretch=�5*      $��Stretch=�5+        � NavigationUIVisibility$ Hidden=�5,      5.      5/      50      