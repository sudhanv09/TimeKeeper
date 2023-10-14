import type { UserTimings } from './types';

function dayOfWeek(date: Date) {
	let weekday = date.getDay();
	weekday = ((weekday + 6) % 7) + 1;
	return weekday.toString();
}

interface TimingDate {
	x: string;
	y: string;
	d: string;
	v: string;
}

export function genData() {
	const d = new Date();
	const today = new Date(d.getFullYear(), d.getMonth(), d.getDate(), 0, 0, 0);
	const end = today;
	let dt = new Date(new Date().setDate(end.getDate() - 180));

	let data: TimingDate[] = [];

	while (dt <= end) {
		const iso = dt.toISOString().substring(0, 10);
			data.push({
				x: iso,
				y: dayOfWeek(dt),
				d: iso,
				v: '0'
			});

		dt = new Date(dt.setDate(dt.getDate() + 1));
	}
	return data;
}

export const data = {
	datasets: [
		{
			label: 'Check-In',
			data: genData(),
			backgroundColor: function (c) {
				const value = c.dataset.data[c.dataIndex].v;
				const alpha = (10 + value) / 60;
				return `rgba(0, 200, 0, ${alpha})`;
			},
			borderColor: 'green',
			borderRadius: 1,
			borderWidth: 1,
			hoverBackgroundColor: 'rgba(255, 26, 104, 0.2)',
			hoverBorderColor: 'rgba(255, 26, 104, 1)',
			width(c) {
				const a = c.chart.chartArea || {};
				return (a.right - a.left) / 53 - 1;
			},
			height(c) {
				const a = c.chart.chartArea || {};
				return (a.bottom - a.top) / 7 - 1;
			}
		}
	]
};

const scales = {
	y: {
		type: 'time',
		offset: true,
		time: {
			unit: 'day',
			round: 'day',
			isoWeekday: 1,
			parser: 'i',
			displayFormats: {
				day: 'iiiiii'
			}
		},
		reverse: true,
		position: 'left',
		ticks: {
			maxRotation: 0,
			autoSkip: true,
			padding: 1,
			font: {
				size: 12
			}
		},
		grid: {
			display: false,
			drawBorder: false,
			tickLength: 0
		}
	},
	x: {
		type: 'time',
		position: 'bottom',
		offset: true,
		time: {
			unit: 'week',
			round: 'week',
			isoWeekday: 1,
			displayFormats: {
				week: 'MMM dd'
			}
		},
		ticks: {
			maxRotation: 0,
			autoSkip: true,
			font: {
				size: 12
			}
		},
		grid: {
			display: false,
			drawBorder: false,
			tickLength: 0
		}
	}
};

export const options = {
	aspectRatio: 5,
	plugins: {
		legend: false,
		tooltip: {
			callbacks: {
				title() {
					return '';
				},
				label(context) {
					const v = context.dataset.data[context.dataIndex];
					return ['x: ' + v.x, 'y: ' + v.y, 'v: ' + v.v];
				}
			}
		}
	},
	scales: scales,
	layout: {
		padding: {
			top: 10
		}
	}
};
