import http from 'k6/http';
import { sleep } from 'k6';


// export const options = {
//     stages: [
//         { duration: '5s', target: 5 },
//         { duration: '30s', target: 5 },
//         { duration: '5s', target: 20 },
//         { duration: '30s', target: 20 },
//         { duration: '5s', target: 5 },
//         { duration: '30s', target: 5 },
//         { duration: '5s', target: 0 },
//     ],
//     thresholds: {
//         http_req_duration: ['p(95)<600'],
//     },
// };


export const options = {
    scenarios: {
      constant_request_rate: {
        executor: 'constant-arrival-rate',
        rate: 100,
        timeUnit: '1s', 
        duration: '1m',
        preAllocatedVUs: 1000, 
        maxVUs: 6000, 
      },
    },
  };


export default function() {
    const response = http.get('http://localhost:5131/WeatherForecast');
    check(response, { "status is 200": (r) => r.status === 200 });
    sleep(.300);
    // sleep(1);
}

