// Listopotamus.Web/aspnetcore-https.js
const { existsSync, mkdirSync } = require('fs');
const { resolve, join } = require('path');
const { spawnSync } = require('child_process');

const certName = process.argv.find(a => a.startsWith('--name='))?.split('=')[1] ?? 'listopotamus-web';
const certFolder = resolve(__dirname, 'certs');
const certPath = join(certFolder, `localhost-cert.pem`);
const keyPath = join(certFolder, `$localhost-key.pem`);

if (!existsSync(certFolder)) {
  mkdirSync(certFolder, { recursive: true });
}

if (!existsSync(certPath) || !existsSync(keyPath)) {
  const result = spawnSync('dotnet', [
    'dev-certs',
    'https',
    '--export-path', certPath,
    '--format', 'Pem',
    '--no-password'
  ], { stdio: 'inherit' });

  if (result.status !== 0) {
    process.exit(result.status);
  }
}
