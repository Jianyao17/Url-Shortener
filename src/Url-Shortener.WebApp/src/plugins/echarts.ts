import { use } from 'echarts/core'

// Charts
import { 
  BarChart, 
  LineChart 
} from 'echarts/charts'

// Components
import {
  GridComponent,
  TooltipComponent,
  LegendComponent,
  AxisPointerComponent,
} from 'echarts/components'

// Renderer
import { SVGRenderer } from 'echarts/renderers'

use([
  BarChart,
  LineChart,
  GridComponent,
  TooltipComponent,
  LegendComponent,
  AxisPointerComponent,
  SVGRenderer,
])


