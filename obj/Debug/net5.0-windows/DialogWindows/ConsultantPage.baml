   M S B A M L   `   `   `  ����I  EBankConsultant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BankConsultantBankConsultant  5      #    BankConsultant.ConsultantPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BankConsultant     5        N� Title$  ConsultantPage��5      $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��Count��5   !   $��1��6   $	��Top=�5      $��Center=�5      $-��'Список пользователей��5      �� 5   
   -   5        $��
ListDbView��5   @   $��1��6   $��2��6   $��0��60   $��	5,20,5,69q�5      5      �� 5   
   $��1��6   $��1��6!   $��Имя��5      $	��Top=�5       $��Center=�5!      �� 5"   
   -   5        $
��Name��5"   /   $��1��6   $��1��6   $��30��5#      $	��Top=�5$      $��10, 20, 10,10q�5%      $��Center=�5&      $��Center=�5'      ${�False��5(      �� 5)   
   $��1��6   $��1��6!   $��Фамилия��5*      $��0, 50, 0 , 0q�5+      $��Center=�5,      �� 5-   
   -   5        $��Surname��5-   /   $��1��6   $��1��6   $��30��5.      $	��Top=�5/      $��10, 70, 10,10q�50      $��Center=�51      $��Center=�52      ${�False��53      �� 54   
   $��1��6   $��1��6!   $��Отчество��55      $��0, 100, 0 , 0q�56      $��Center=�57      �� 58   
   -   5        $��
SecondName��58   /   $��1��6   $��1��6   $��30��59      $	��Top=�5:      $��10, 120, 10,10q�5;      $��Center=�5<      $��Center=�5=      ${�False��5>      �� 5?   
   $��1��6   $��1��6!   $!��Номер телефона��5@      $��0, 150, 0 , 0q�5A      $��Center=�5B      �� 5C   
   -   5        $��PhoneNumber��5C   /   $��1��6   $��1��6   $��30��5D      $	��Top=�5E      $��10, 170, 10,10q�5F      $��Center=�5G      $��Center=�5H      �� 5I   
   $��1��6   $��2��6!   $!��Серия паспорта��5J      $��0, 0, 0 , 0q�5K      $��Center=�5L      �� 5M   
   -   5        $��PassportSeries��5M   /   $��1��6   $��2��6   $��30��5N      $	��Top=�5O      $��10, 20, 10,10q�5P      $��Center=�5Q      $��Center=�5R      ${�False��5S      �� 5T   
   $��1��6   $��2��6!   $!��Номер паспорта��5U      $��0, 50, 0 , 0q�5V      $��Center=�5W      �� 5X   
   -   5        $��PassportNumber��5X   /   $��1��6   $��2��6   $��30��5Y      $	��Top=�5Z      $��10, 70, 10,10q�5[      $��Center=�5\      $��Center=�5]      ${�False��5^      �� 5_   
   -	   5        $��
SaveButton��5_   .   $��2��6   $��2��6   $��50��5`      $	��Top=�5a      $��10,146,10,0q�5b      $��Сохранить��5c      $��20(�5d      
�������5f      �� 5h   
   -
   5        $��Check��5h   /   $��2��6   $��1��6   $	��113��5i      $	��Top=�5j      $��
10,28,10,0q�5k      ${�False��5l      $��Center=�5m      $��Center=�5n      $��12(�64   �� 5o   
   -   5         ��Name$ 
WhoChanged��5o   /   $��2��6   $��2��6   $��30��5p      $	��Top=�5q      $��
10,28,10,0q�5r      $��Center=�5s      $��Center=�5t      ${�False��5u      �� 5v   
   -   5        $ WhenChanged��5v   /   $��2��6   $��2��6   $��30��5w      $	��Top=�5x      $��
10,84,10,0q�5y      $��Center=�5z      $��Center=�5{      ${�False��5|      �� 5}   
   $��2��6   $��2��6!   $;��5Кто внес последние изменения��5~      $��Center=�5      $��	0,5,0,182q�6*   �� 5�   
   $��2��6   $��2��6!   $;��5Когда были внесены изменения��5�      $��Center=�5�      $��
0,61,0,126q�6*   �� 5�   
   $��2��6   $��1��6!   $+��%Последние изменения��5�      $	��Top=�5�      $��Center=�5�      $��0,10,0,0q�6*   $	��148��6<   �� 5�   
   -   5         ��Name$ 
SortButton��5�      $��2��6   $��50��5�      $	��Top=�5�      $��5,146,161,0q�5�      $��Сортировка��5�      $��15(�5�      
�������5�      �� 5�   
   -   5        $ DeleteButton��5�      $��2��6   $��50��5�      $	��Top=�5�      $��161,146,5,0q�5�      $��Удалить��5�      $��15(�5�      
�������5�      5�      5�      