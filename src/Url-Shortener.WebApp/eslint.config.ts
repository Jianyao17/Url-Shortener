import { globalIgnores } from 'eslint/config';
import { defineConfigWithVueTs, vueTsConfigs } from '@vue/eslint-config-typescript';
import pluginVue from 'eslint-plugin-vue';
import pluginVitest from '@vitest/eslint-plugin';

// To allow more languages other than `ts` in `.vue` files, uncomment the following lines:
// import { configureVueProject } from '@vue/eslint-config-typescript'
// configureVueProject({ scriptLangs: ['ts', 'tsx'] })
// More info at https://github.com/vuejs/eslint-config-typescript/#advanced-setup

export default defineConfigWithVueTs(
  // Target file untuk linting
  {
    name: 'app/files',
    files: ['**/*.{ts,mts,tsx,vue}'],
  },

  // Abaikan folder build
  globalIgnores(['dist/**', 'dist-ssr/**', 'coverage/**']),

  // Basic Vue rules
  pluginVue.configs['flat/essential'],

  // Basic TypeScript rules
  vueTsConfigs.recommended,

  // Vitest testing rules
  {
    ...pluginVitest.configs.recommended,
    files: ['src/**/__tests__/*'],
  },

  // CUSTOM RULES sesuai gaya koding kamu
  {
    name: 'custom-style',
    rules: {
      // Gaya curly bracket Allman (baris baru)
      'brace-style': ['error', 'allman', { allowSingleLine: true }],

      // Arrow function 1 baris tetap 1 baris
      'arrow-body-style': ['error', 'as-needed'],

      // Jangan paksa newline setelah =>
      'implicit-arrow-linebreak': 'off',

      // Jangan paksa { } multiline
      'object-curly-newline': 'off',

      // Format block basic
      'block-spacing': ['error', 'always'],

      // Buat kode nyaman tanpa newline wajib
      'padding-line-between-statements': 'off',

      // Paksa konsistensi indent 2 spasi
      'indent': ['error', 2, { SwitchCase: 1 }],

      // Single quotes
      'quotes': ['error', 'single'],

      // Selalu pakai semicolon
      'semi': ['error', 'always'],

      /* Vue spesifik */
      
      // Script tag left aligned
      'vue/script-indent': ['error', 0, 
      {
        baseIndent: 0,
        switchCase: 0
      }],

      // Template indentation 2 spasi
      'vue/html-indent': ['error', 2],

      // Style tag left aligned
      'vue/block-tag-newline': ['error', 
      {
        singleline: 'always',
        multiline: 'always'
      }],
    },
  }
);
