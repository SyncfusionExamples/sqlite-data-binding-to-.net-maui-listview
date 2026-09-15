# SQLite data binding to the .NET MAUI ListView (SfListView)

This example describes how to perform SQLite data binding to the .NET MAUI ListView (SfListView).

## Sample

```xaml
<syncfusion:SfListView x:Name="listView"  
                                TapCommand="{Binding EditContactsCommand}"
                                ScrollBarVisibility="Always"
                                ItemSize="70">
    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <ViewCell.View>
                    <Grid x:Name="grid" RowSpacing="0">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*" />
                            <RowDefinition Height="1" />
                        </Grid.RowDefinitions>
                        <Grid RowSpacing="0">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="70" />
                                <ColumnDefinition Width="*" />
                                <ColumnDefinition Width="Auto" />
                            </Grid.ColumnDefinitions>

                            <Image Source="{Binding Image}"
                    VerticalOptions="Center"
                    HorizontalOptions="Center"
                    HeightRequest="50" WidthRequest="50"/>

                            <Grid Grid.Column="1"
                    RowSpacing="1"
                    Padding="10,0,0,0"
                    VerticalOptions="Center">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="*" />
                                    <RowDefinition Height="*" />
                                </Grid.RowDefinitions>

                                <Label LineBreakMode="NoWrap"
                                            TextColor="#474747"
                                            Text="{Binding Name}"
                                            FontSize="{OnPlatform Android={OnIdiom Phone=16, Tablet=18}, iOS={OnIdiom Phone=16, Tablet=18}, MacCatalyst=18, WinUI={OnIdiom Phone=18, Tablet=20, Desktop=20}}" />
                                <Label Grid.Row="1"
                                            Grid.Column="0"
                                            TextColor="#474747"
                                            LineBreakMode="NoWrap"
                                            Text="{Binding Number}"
                                            FontSize="{OnPlatform Android={OnIdiom Phone=12, Tablet=14}, iOS={OnIdiom Phone=12, Tablet=14}, MacCatalyst=14, WinUI={OnIdiom Phone=12, Tablet=12, Desktop=12}}" />
                            </Grid>
                            <Grid Grid.Row="0"
                    Grid.Column="2"
                    RowSpacing="0"
                    HorizontalOptions="End" VerticalOptions="Start"
                                        Padding='{OnPlatform Default="0,10,10,0", MacCatalyst="0,10,15,0"}'>
                                <Label LineBreakMode="NoWrap"
                                            TextColor="#474747"
                                            Text="{Binding ContactType}"
                                            FontSize="{OnPlatform Android={OnIdiom Phone=10, Tablet=12}, iOS={OnIdiom Phone=10, Tablet=12}, MacCatalyst=12, WinUI={OnIdiom Phone=10, Tablet=11, Desktop=11}}" />
                            </Grid>
                        </Grid>
                        <StackLayout Grid.Row="1" BackgroundColor="#E4E4E4" HeightRequest="1"/>
                    </Grid>
                </ViewCell.View>
            </ViewCell>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

