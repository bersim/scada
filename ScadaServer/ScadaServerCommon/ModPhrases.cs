﻿/*
 * Copyright 2015 Mikhail Shiryaev
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * 
 * Product  : Rapid SCADA
 * Module   : ScadaServerCommon
 * Summary  : The phrases used in server modules
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2015
 * Modified : 2015
 */

#pragma warning disable 1591 // отключение warning CS1591: Missing XML comment for publicly visible type or member

namespace Scada.Server.Modules
{
    /// <summary>
    /// The phrases used in server modules
    /// <para>Фразы, используемые серверными модулями</para>
    /// </summary>
    public static class ModPhrases
    {
        static ModPhrases()
        {
            SetToDefault();
            InitOnLocalization();
        }

        // Словарь Scada.Server.Modules
        public static string LoadCommSettingsError { get; private set; }
        public static string SaveCommSettingsError { get; private set; }
        public static string LoadModSettingsError { get; private set; }
        public static string SaveModSettingsError { get; private set; }

        // Фразы, устанавливаемые в зависимости от локализации, не загружая из словаря
        public static string StartModule { get; private set; }
        public static string StopModule { get; private set; }
        public static string NormalModExecImpossible { get; private set; }

        private static void SetToDefault()
        {
            LoadCommSettingsError = "Ошибка при загрузке настроек соединения с сервером";
            SaveCommSettingsError = "Ошибка при сохранении настроек соединения с сервером";
            LoadModSettingsError = "Ошибка при загрузке настроек модуля";
            SaveModSettingsError = "Ошибка при сохранении настроек модуля";

        }

        private static void InitOnLocalization()
        {
            if (Localization.UseRussian)
            {
                StartModule = "Запуск работы модуля {0}";
                StopModule = "Работа модуля {0} завершена";
                NormalModExecImpossible = "Нормальная работа модуля невозможна";
            }
            else
            {
                StartModule = "Start {0} module";
                StopModule = "Module {0} is stopped";
                NormalModExecImpossible = "Normal module execution is impossible";
            }
        }

        public static void InitFromDictionaries()
        {
            Localization.Dict dict;
            if (Localization.Dictionaries.TryGetValue("Scada.Server", out dict))
            {
                LoadCommSettingsError = dict.GetPhrase("LoadCommSettingsError", LoadCommSettingsError);
                SaveCommSettingsError = dict.GetPhrase("SaveCommSettingsError", SaveCommSettingsError);
                LoadModSettingsError = dict.GetPhrase("LoadModSettingsError", LoadModSettingsError);
                SaveModSettingsError = dict.GetPhrase("SaveModSettingsError", SaveModSettingsError);
            }
        }
    }
}
