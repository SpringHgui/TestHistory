import { fileURLToPath, URL } from 'url'

import { defineConfig, loadEnv } from 'vite'
import vue from '@vitejs/plugin-vue'

export default ({ mode }) => {
  console.log(mode);
  process.env = { ...process.env, ...loadEnv(mode, process.cwd()) };

  // https://vitejs.dev/config/
  return defineConfig({
    plugins: [vue()],
    resolve: {
      alias: {
        '@': fileURLToPath(new URL('./src', import.meta.url))
      }
    },
    base: process.env.VITE_APP_BASE || "/"
  })
}