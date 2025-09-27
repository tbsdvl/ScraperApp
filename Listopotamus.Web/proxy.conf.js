const PROXY_CONFIG = [{
  "/identity": {
    "target": "https://localhost:7112",
    "secure": false,
    "changeOrigin": true,
    "logLevel": "debug",
    "headers": {
      "Connection": "keep-alive"
    }
  }
}];

module.exports = PROXY_CONFIG;