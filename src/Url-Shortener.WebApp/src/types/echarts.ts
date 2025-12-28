// Chart
import type { 
  BarSeriesOption, 
  LineSeriesOption 
} from 'echarts/charts'

// Components
import type {
  GridComponentOption,
  TooltipComponentOption,
  LegendComponentOption,
  AxisPointerComponentOption
} from 'echarts/components'

// Compose Option
import type { ComposeOption } from 'echarts/core'

// Export a composed option type
export type EChartsOption = ComposeOption<
  | GridComponentOption
  | TooltipComponentOption
  | LegendComponentOption
  | AxisPointerComponentOption
  | BarSeriesOption
  | LineSeriesOption
>

