# CDT.Valheim.LocaleEx

# English

CDT.Valheim.LocaleEx is created with the purpose of making the tasks of translation and distribution of community translations easier. This method does not interfere with or modify the game processing files, thus it does not impact the game and remains unaffected during game updates.

This mod directly intervenes in the game's multilingual processor, automatically initializing the default language file (English) of the game when launched. It uses JSON format for language extension files and loads them from the `locales` folder in the game directory.

## For Players

Visit the [Releases](https://github.com/CoDongThon/CDT.Valheim.LocaleEx/releases) section, and download the latest version listed there.

Typically, the packaged release will include all necessary components to run the game with the extended language. This will include the JSON processing library, mod loader, BepInEx framework, the mod file, and the language file contributed by the community.

If you are unfamiliar with the terms BepInEx or game mods, it's likely that your game has not applied any mods before. In that case, simply unzip the downloaded file and copy it to the game directory. Due to the special mechanism of the mod loader, no original game files will be changed, so there will be no overwrite warnings.

You can also update your game with confidence; this will not cause any conflicts with the mod.

If your game already has BepInEx installed, make sure it's version 5.*, then:
- copy the plugin `BepInEx/plugins/CDT.Valheim.LocaleEx.dll` into the game's `BepInEx/plugins` directory
- copy the `Newtonsoft.Json.dll` file into the game directory
- finally, copy the `locales` folder into the game directory.

Once these steps are completed, you're done. Now, launch the game and enjoy.

_Note: Keep an eye on new updates in this repository!!!_

## For Translators

After installation following the instructions above. When you open the game, the file `locales/default.json` will always be updated (even if there are no actual changes). As the name suggests, LocaleEx considers this file as the default original file of the game, and updating this ensures that the content of the `default.json` file matches the current content of the game.

To perform translation, pay attention to the `locales/` folder:
- File `default.json`: Includes the English content of the game, updated every time the game is launched.
- File `common.json`: Includes common language content, will be loaded by LocaleEx under any circumstances, in any language setting.
- File `lang_*.json`: These are additional language files, changing the content in these corresponds to each language pack in the game. For example, the file `lang_Vietnamese.json` corresponds to the Vietnamese language in the game settings.

If you want to add a new language in the game, copy (or rename) the `default.json` file to the format `lang_*.json`, where `*` corresponds to the language ID. Keep it in English and without spaces, or set it to an international symbol. Then, update the `common.json` file to include the friendly display name in the game language settings.
After completion, reopen the game and go to the settings to check if the game has loaded the new language pack.

Now, you can edit the content in your `lang_*.json` file to start translating the game. When done with the changes, simply reopen the settings, switch between the game languages, or reopen the game to see the translated content.

__It is recommended to use [VSCode](https://vscode.dev) or advanced JSON file editors to minimize errors during the game translation process.__

# Vietnamese

CDT.Valheim.LocaleEx được tạo ra với mục đích giúp công việc chuyển ngữ và phân phối bản dịch cộng đồng trở nên dễ dàng. Phương pháp này không can thiệp thay đổi tệp xử lý game, do vậy không gây ảnh hưởng tới game và không bị game ảnh hưởng khi thực hiện cập nhật game lên phiên bản mới. 

Bản mod này can thiệp trực tiếp vào trình xử lý đa ngữ của game, tự động khởi tạo tệp ngôn ngữ mặc định (tiếng anh) của game khi khởi chạy. Sử dụng định dạng JSON cho các tệp ngôn ngữ mở rộng và tải chúng từ thư mục `locales` tại thư mục game.

## Dành cho người chơi

Truy cập vào [Bản dựng](https://github.com/CoDongThon/CDT.Valheim.LocaleEx/releases), tải phiên bản mới nhất được liệt kê tại đó.

Thông thường bản đóng gói sẽ bao gồm toàn bộ các thành phần cần thiết để khởi chạy game cùng ngôn ngữ mở rộng. Trong đó sẽ có thư viện xử lý JSON, mod loader và khung BepInEx, cuối cùng là tệp mod và tệp ngôn ngữ do cộng đồng đóng góp.

Nếu bạn không biết thuật ngữ BepInEx hay mod game là gì, khả năng cao bản game của bạn chưa từng áp dụng bản mod nào. Nếu vậy thì bạn chỉ cần giải nén tệp đã tải sau đó copy vào thu mục chứa game. Do cơ chế đặc biệt của mod loader, không thay đổi bất kỳ tệp game gốc nào nên sẽ không có bất kỳ cảnh báo ghi đè nào hiển thị ra cả.

Bạn cũng hoàn toàn yên tâm khi cập nhật game, việc này không gây ra bất kỳ xung đột nào với bản mod.

Còn nếu bản game của bạn đã cài BepInEx, hãy đảm bảo BepInEx ở phiên bản 5.*, tiếp theo:
- copy plugin `BepInEx/plugins/CDT.Valheim.LocaleEx.dll` vào thư mục `BepInEx/plugins` của game
- copy tệp `Newtonsoft.Json.dll` vào thu mục game
- cuối cùng là copy thư mục `locales` vào thư mục game.

Hoàn thành các bước trên là xong, giờ mở game lên và tận hưởng thôi.

_Lưu ý: theo dõi thêm nội dung mới cập nhật ở kho này nhé!!!_

Ở thời điểm ra mắt LocaleEx 1.0.0, gói ngôn ngữ Tiếng Việt chưa được hoàn thiện, nó bao gồm ngôn ngữ tiếng anh ở phiên bản Valheim 0.217.38 cùng với nội dung Việt Ngữ của của [EICP](https://gametiengviet.com/threads/valheim-viet-ngu.5425/) cho phiên bản Valheim 0.202.19.

## Dành cho người chuyển ngữ

Sau khi đã cài đặt xong như hướng dẫn phía trên. Sau khi mở game, tệp `locales/default.json` sẽ luôn được cập nhật (ngay cả khi không có thay đổi thực sự nào). Giống như tên gọi, LocaleEx sẽ coi tệp này là tệp gốc mặc định của game, việc cập nhật lại này sẽ luôn đảm bảo rằng nội dung tệp `default.json` khớp với nội dung hiện tại của game.

Để thực hiện chuyển ngữ, hãy chú ý vào thư mục `locales/`:
- Tệp `default.json`: Bao gồm nội dung tiếng anh của game, được cập nhật lại mỗi khi mở game.
- Tệp `common.json`: Bao gồm nội dung ngôn ngữ mặc định, sẽ được LocaleEx tải dưới bất kỳ hoàn cảnh nào, ở bất kỳ cài đặt ngôn ngữ nào.
- Tệp `lang_*.json`: Đây là những tệp ngôn ngữ bổ sung, thay đổi nội dung trong này tương ứng với từng gói ngôn ngữ trong game. Vd: tệp `lang_Vietnamese.json` tương ứng với ngôn ngữ Tiếng Việt trong cài đặt game.

Nếu bạn muốn bổ sung ngôn ngữ mới trong game, hãy sao chép (hoặc đổi tên) tệp `default.json` thành dạng `lang_*.json`, trong đó `*` tương ứng với id của ngôn ngữ, bạn nên để nó ở ngôn ngữ tiếng anh và không có khoảng trống, hoặc đặt bằng ký hiệu quốc tế. Tiếp đó hãy cập nhật tệp `common.json` để bao gồm tên hiển thị thân thiện trong cài đặt ngôn ngữ game.
Sau khi hoàn thành, mở lại game và truy cập phần cài đặt để xác định xem game đã tải gói ngôn ngữ mới chưa.

Lúc này, bạn có thể chỉnh sửa nội dung có trong tệp `lang_*.json` của bạn để bắt đầu chuyển ngữ game. Khi xong các phần thay đổi, chỉ cần mở lại cài đặt, chuyển qua lại giữa ngôn ngữ game hoặc mở lại game để thấy nội dung đã chuyển ngữ.

__Khuyến nghị nên sử dụng [VSCode](https://vscode.dev) hoặc các trình chỉnh sửa tệp JSON nâng cao để hạn chế lỗi trong quá trình chuyển ngữ game.__