# AnimationClipToVrmaSample

ヒューマノイドのモーションからなるAnimation Clipを VRM Animation (.vrma) に変換するプロジェクトです。

※この方法では変換した`.vrma`ファイルにはモデルの骨格情報が埋め込まれます。とくに`.vrma`ファイルの再配布を検討している場合、このREADMEを必ず最後まで読んで下さい。

Sample Project to convert AnimationClip asset to VRM Animation (.vrma) in Unity.

*The document below is in Japanese, except `Notice about License` section. If you want to redistribute `.vrma` file, you also MUST understand what is written in `Notice about VRMA file redistribution` section.

# Install

- Projectを丸ごと使う場合:
    - このレポジトリ自体をcloneし、プロジェクトとして開く
- 既存のプロジェクトに変換用の処理を導入する場合: 
    - 使用中のプロジェクトに[UniVRM 0.115.0](https://github.com/vrm-c/UniVRM/releases/tag/v0.115.0)を導入
    - Releasesページのunitypackageをダウンロードしてプロジェクトに追加

# Usage

## 必要なもの

- Humanoid向けにセットアップされたAnimationClip
- (変換方法2でのみ必要) AnimationClipの再生に用いるヒューマノイドのアバター

AnimationClipは単独のファイル、またはFBXファイルの一部として含まれるデータのいずれでも構いません。

アバターはVRMでのみ動作確認していますが、VRM以外のモデルでも動作する想定です。

プロジェクトをcloneした場合、AnimationClipとアバター双方のサンプルが同梱されています。


## 変換方法1: AnimationClipの右クリックから変換

プロジェクトビュー上でAnimationClipアセットを右クリックして`VRM/Convert to VRM Animation`を実行して保存先を指定することで`.vrma`ファイルがエクスポートされます。

![Right Click on Clip](./img/right_click_on_clip.png)

この方法ではVRoidのサンプルモデルの骨格をリファレンスとした`.vrma`が出力され、リファレンスモデルは選択できません。

この出力で得た`.vrma`を適用して見た目が問題ない場合、この手順は簡便に利用できます。


## 変換方法2: VRM Animation Exporterウィンドウから変換

`.vrma`ファイルのエクスポート時に参照するアバターをシーン上に配置しておきます。

※このアバターのボーンがAnimationClipの値に沿って操作されます。

メニューバーから`VRM/VRM Animation Exporter`を選択して`VRM Animation Exporter`ウィンドウを表示し、次のように指定します。

- `Avatar`: シーン上に配置したアバター
- `Animation`: 変換したいAnimationClip

その後、`Export`ボタンを選択することで `.vrma` ファイルを出力します。

![VRM Animation Exporter Window](./img/vrm_animation_exporter_window.png)

この方法では、VRM Animationを再生したいアバターそのものの骨格を参照して`.vrma`ファイルを出力できるため、モーションの再現性が高くなります。


# 変換後のVRM Animationが正常に動作する事を確認する方法

VRM Animationの適用対象となるアバターのVRMファイルを用意しておきます。


UniVRM 0.115.0のサンプルパッケージを導入します。

- リリース: https://github.com/vrm-c/UniVRM/releases/tag/v0.115.0
- unitypackage: https://github.com/vrm-c/UniVRM/releases/download/v0.115.0/VRM_Samples-0.115.0_7e05.unitypackage

*本レポジトリでは上記パッケージに含まれる`VRM10_Samples`フォルダをgitignoreの対象としています。

パッケージの導入後、`VRM10_Samples/SimpleVrma/SimpleVrma`シーンを開いて実行し、アバターと`.vrma`ファイルを読み込むことで動作を確認します。

シーンを実行すると`.vrma`の骨格に基づくCubeベースのモデルも表示されますが、これは`BoxMan`チェックをオフにすれば非表示になります。

![Check VRM in Sample Scene](./img/check_vrma_in_simple_vrma_scene.png)


# Notice about VRMA file redistribution

VRM Animationのファイル内には、アニメーションの再生を実行したモデルのHumanoidボーンの骨格情報が埋め込まれます。

このことに基づき、とくにVRM Animationファイルの再配布を考えている場合は次のことに留意してください。

- モデル自体の再配布が許可され、クレジット表記が不要であるものを用いることを検討して下さい。
- VRM Animationの生成に使用したのがどのモデルであるか記録を取ることを検討して下さい。

ただし、この注意はレポジトリ自体のライセンスとは関連しません。


# Notice about License

- `Assets/Model_VRoidSampleA` フォルダ内のファイルはVRMファイル自体のライセンスに従います。
    - 取得元: [AvatarSample_A](https://hub.vroid.com/characters/2843975675147313744/models/5644550979324015604)
- `Assets/Scripts/ReferenceModelBasedConvert/Model_Value.cs` スクリプトは上記モデルの骨格情報に相当する値であるため、この値をそのまま使う場合はVRMのライセンスに沿ってご使用下さい。
    - このライセンスは、AnimationClipを直接右クリックして`Convert to VRM Animation`を実行する場合に影響します。`VRM Animation Exporter`ウィンドウを使用している場合、この数値は使用されません。
- 上記を除くリソースは`LICENSE`ファイルに従います。


- Model data in `Assets/Model_VRoidSampleA` has own license based on VRM data format.
    - Model Source: [AvatarSample_A](https://hub.vroid.com/characters/2843975675147313744/models/5644550979324015604)
- Bone pose values in `Assets/Scripts/ReferenceModelBasedConvert/Model_Value.cs` come from the model above. When you use `Convert to VRM Animation` feature by right-clicking AnimationClip asset, please confirm the VRM's license.
- Other resources in the repository is under the license in `LICENSE` file.



# For Developer: Update Model_Value.cs content based on another model

このセクションはAnimationClipを右クリックして`Convert to VRM Animation`する機能に関する補足です。

`Assets/Scripts/ReferenceModelBasedConvert/Model_Value.cs`の値は前述したモデルのライセンスに従っていますが、この値を異なるヒューマノイドの姿勢値で上書きして使用できます。

値を上書きする場合、任意ボーンも含めた全てのHumanoid用ボーンを備えたモデルを使用して下さい。

(TODO: 手順は追記予定です)
