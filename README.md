## Client


```bash
python -m SimpleHTTPServer

wrk -t2 -d1m https://localhost:5001/api/google/fetch

curl -k https://localhost:5001/api/google/go
curl -k https://localhost:5001/api/google/fetch

curl -k https://localhost:5001/weatherForecast

netstat -na | grep 8000
```
